using System;
using System.ComponentModel.DataAnnotations;
using Tilbake.Domain.Enums;

namespace Tilbake.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class DateTimeCompareAttribute : PropertyValidationAttribute
    {
        #region Fields

        private readonly ValueComparison comparison;
        private readonly ValidationResult failure;
        private readonly ValidationResult success;

        #endregion

        #region Ctor

        public DateTimeCompareAttribute(string otherProperty, ValueComparison comparison) : base(otherProperty)
        {
            if (!Enum.IsDefined(typeof(ValueComparison), comparison))
                throw new ArgumentException(Properties.Resources.UndefinedValue, nameof(comparison));

            this.comparison = comparison;
            this.success = ValidationResult.Success;
            this.failure = new ValidationResult(String.Empty);
        }
        #endregion

        #region Overrides
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? date = GetDate(value);

                if (date.HasValue)
                {
                    return IsValid(date.Value, validationContext);
                }
            }
            return success;
        }

        #endregion

        #region Methods

        private static DateTime? GetDate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            };

            DateTime? date = null;

            if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else if (value is DateTime?)
            {
                date = (DateTime?)value;
            }
            return date;
        }

        private ValidationResult IsValid(DateTime value, ValidationContext validationContext)
        {
            object otherValue = GetValue(validationContext);

            if (otherValue != null)
            {
                DateTime? otherDate = GetDate(otherValue);

                if (otherDate.HasValue)
                {
                    return IsValid(value, otherDate.Value);
                }
            }
            return success;
        }

        private ValidationResult IsValid(DateTime value, DateTime otherValue)
        {
            switch (comparison)
            {
                case ValueComparison.IsEqual:
                    if (value != otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsNotEqual:
                    if (value == otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsGreaterThan:
                    if (value <= otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsGreaterThanOrEqual:
                    if (value < otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsLessThan:
                    if (value >= otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsLessThanOrEqual:
                    if (value > otherValue)
                    {
                        return failure;
                    }
                    break;
            }
            return success;
        }
        #endregion
    }
}
