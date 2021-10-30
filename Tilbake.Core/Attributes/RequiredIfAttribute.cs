using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Core.Enums;

namespace Tilbake.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class RequiredIfAttribute : PropertyValidationAttribute
    {
        #region Fields

        private readonly ValueComparison comparison;
        private readonly ValidationResult failure;
        private readonly ValidationResult success;
        private readonly object compare;

        #endregion

        #region Ctor

        public RequiredIfAttribute(string otherPropertyName, object compare, ValueComparison comparison) : base(otherPropertyName)
        {
            if (!Enum.IsDefined(typeof(ValueComparison), comparison))
                throw new ArgumentException(Properties.Resources.UndefinedValue, nameof(comparison));

            this.comparison = comparison;
            this.success = ValidationResult.Success;
            this.failure = new ValidationResult(String.Empty);
            this.compare = compare;
        }

        #endregion

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (compare != null)
            {
                object otherValue = GetValue(validationContext);

                if (otherValue == null)
                {
                    return success;
                }

                IComparable comparable = otherValue as IComparable;

                int result = comparable.CompareTo(compare);

                bool require = Compare(result);

                if (require)
                {
                    if (value == null)
                    {
                        return failure;
                    }

                    if (value is string str)
                    {
                        if (str.Length == 0)
                        {
                            return failure;
                        }
                    }
                }
            }

            return success;
        }

        private bool Compare(int comparisonResult)
        {
            switch (comparison)
            {
                case ValueComparison.IsEqual:
                    if (comparisonResult == 0)
                    {
                        return true;
                    }
                    break;
                case ValueComparison.IsNotEqual:
                    if (comparisonResult != 0)
                    {
                        return true;
                    }
                    break;
                case ValueComparison.IsLessThan:
                    if (comparisonResult < 0)
                    {
                        return true;
                    }
                    break;
                case ValueComparison.IsGreaterThan:
                    if (comparisonResult > 0)
                    {
                        return true;
                    }
                    break;
                case ValueComparison.IsLessThanOrEqual:
                    if (comparisonResult < 0 || comparisonResult == 0)
                    {
                        return true;
                    }
                    break;
                case ValueComparison.IsGreaterThanOrEqual:
                    if (comparisonResult > 0 || comparisonResult == 0)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        #endregion
    }
}
