using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace Tilbake.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class PropertyValidationAttribute : ValidationAttribute
    {
        #region Fields
        private readonly string propertyName;
        private object value;
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        #endregion

        #region Ctor

        protected PropertyValidationAttribute(string propertyName) : base()
        {
            if (String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            this.propertyName = propertyName;
        }

        #endregion

        #region Properties

        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        protected string PropertyName
        {
            get { return this.propertyName; }
        }

        #endregion

        #region Methods

        protected object GetValue(ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            };

            Type type = validationContext.ObjectType;
            PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);

            if (property == null)
            {
                String s = String.Format(culture, Properties.Resources.TypeDoesNotContainPublicInstanceProperty, type.FullName, PropertyName);
                throw new InvalidOperationException(s);
            }

            if (IsIndexerProperty(property))
            {
                String s = String.Format(culture, Properties.Resources.PropertyWithIndexerParametersNotSupported);
                throw new NotSupportedException(s);
            }


            value = property.GetValue(validationContext.ObjectInstance);

            return value;
        }

        private static bool IsIndexerProperty(PropertyInfo property)
        {
            var parameters = property.GetIndexParameters();

            return (parameters != null && parameters.Length > 0);
        }

        #endregion
    }
}
