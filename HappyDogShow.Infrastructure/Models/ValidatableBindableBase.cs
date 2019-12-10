using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogShow.Infrastructure.Models
{
    public class ErrorsContainer<T>
    {
        private static readonly T[] noErrors = new T[0];
        private readonly Action<string> raiseErrorsChanged;
        private readonly Dictionary<string, List<T>> validationResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsContainer{T}"/> class.
        /// </summary>
        /// <param name="raiseErrorsChanged">The action that invoked if when errors are added for an object./>
        /// event.</param>
        public ErrorsContainer(Action<string> raiseErrorsChanged)
        {
            if (raiseErrorsChanged == null)
            {
                throw new ArgumentNullException("raiseErrorsChanged");
            }

            this.raiseErrorsChanged = raiseErrorsChanged;
            this.validationResults = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// Gets a value indicating whether the object has validation errors. 
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return this.validationResults.Count != 0;
            }
        }

        /// <summary>
        /// Returns all the errors in the container
        /// </summary>
        /// <returns>The dictionary of errors per property.</returns>
        public Dictionary<string, List<T>> GetAllErrors()
        {
            return validationResults;
        }

        /// <summary>
        /// Gets the validation errors for a specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The validation errors of type <typeparamref name="T"/> for the property.</returns>
        public IEnumerable<T> GetErrors(string propertyName)
        {
            var localPropertyName = propertyName ?? string.Empty;
            List<T> currentValidationResults = null;
            if (this.validationResults.TryGetValue(localPropertyName, out currentValidationResults))
            {
                return currentValidationResults;
            }
            else
            {
                return noErrors;
            }
        }

        /// <summary>
        /// Gets the validation errors for a specified property.
        /// </summary>
        /// <typeparam name="TProperty">The Type parameter for what the property type is. Can be inferred implicitly.</typeparam>
        /// <param name="propertyExpression">The expression indicating a property.</param>
        /// <returns>The validation errors of type <typeparamref name="T"/> for the property.</returns>
        public IEnumerable<T> GetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            return this.GetErrors(propertyName);
        }

        /// <summary>
        /// Clears the errors for the property indicated by the property expression.
        /// </summary>
        /// <typeparam name="TProperty">The property type.</typeparam>
        /// <param name="propertyExpression">The expression indicating a property.</param>
        /// <example>
        ///     container.ClearErrors(()=>SomeProperty);
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void ClearErrors<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.ClearErrors(propertyName);
        }

        /// <summary>
        /// Clears the errors for a property.
        /// </summary>
        /// <param name="propertyName">The name of th property for which to clear errors.</param>
        /// <example>
        ///     container.ClearErrors("SomeProperty");
        /// </example>
        public void ClearErrors(string propertyName)
        {
            this.SetErrors(propertyName, new List<T>());
        }

        /// <summary>
        /// Sets the validation errors for the specified property.
        /// </summary>
        /// <typeparam name="TProperty">The property type for which to set errors.</typeparam>
        /// <param name="propertyExpression">The <see cref="Expression"/> indicating the property.</param>
        /// <param name="propertyErrors">The list of errors to set for the property.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void SetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression, IEnumerable<T> propertyErrors)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.SetErrors(propertyName, propertyErrors);
        }

        /// <summary>
        /// Sets the validation errors for the specified property.
        /// </summary>
        /// <remarks>
        /// If a change is detected then the errors changed event is raised.
        /// </remarks>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="newValidationResults">The new validation errors.</param>
        public void SetErrors(string propertyName, IEnumerable<T> newValidationResults)
        {
            var localPropertyName = propertyName ?? string.Empty;
            var hasCurrentValidationResults = this.validationResults.ContainsKey(localPropertyName);
            var hasNewValidationResults = newValidationResults != null && newValidationResults.Count() > 0;

            if (hasCurrentValidationResults || hasNewValidationResults)
            {
                if (hasNewValidationResults)
                {
                    this.validationResults[localPropertyName] = new List<T>(newValidationResults);
                    this.raiseErrorsChanged(localPropertyName);
                }
                else
                {
                    this.validationResults.Remove(localPropertyName);
                    this.raiseErrorsChanged(localPropertyName);
                }
            }
        }
    }

    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo, IDirtyAwareEntity
    {
        public bool IsDirty { get; set; }
        ErrorsContainer<string> _errorsContainer;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            return ErrorsContainer.GetErrors(propertyName);
        }

        public void SetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression, IEnumerable<string> errors)
        {
            ErrorsContainer.SetErrors(propertyExpression, errors);
        }

        private bool hasErrors;
        public bool HasErrors
        {
            get { return hasErrors; }
            set { SetProperty(ref hasErrors, value); }
        }

        public Dictionary<string, List<string>> GetAllErrors()
        {
            return ErrorsContainer.GetAllErrors();
        }


        protected ErrorsContainer<string> ErrorsContainer
        {
            get
            {
                if (_errorsContainer == null)
                {
                    _errorsContainer =
                        new ErrorsContainer<string>(pn => this.RaiseErrorsChanged(pn));
                }

                return _errorsContainer;
            }
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            HasErrors = ErrorsContainer.HasErrors;
            ErrorsChanged(this, e);
        }

        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var result = base.SetProperty(ref storage, value, propertyName);
            IsDirty = true;

            if (result && !string.IsNullOrEmpty(propertyName))
            {
                ValidateProperty(propertyName);
            }
            return result;
        }

        public bool ValidateProperty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var propertyInfo = this.GetType().GetRuntimeProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            var propertyErrors = new List<string>();
            bool isValid = TryValidateProperty(propertyInfo, propertyErrors);
            ErrorsContainer.SetErrors(propertyInfo.Name, propertyErrors);

            return isValid;
        }

        public bool ValidateProperties()
        {
            var propertiesWithChangedErrors = new List<string>();

            // Get all the properties decorated with the ValidationAttribute attribute.
            var propertiesToValidate = this.GetType()
                                                        .GetRuntimeProperties()
                                                        .Where(c => c.GetCustomAttributes(typeof(ValidationAttribute)).Any());

            foreach (PropertyInfo propertyInfo in propertiesToValidate)
            {
                var propertyErrors = new List<string>();
                TryValidateProperty(propertyInfo, propertyErrors);

                // If the errors have changed, save the property name to notify the update at the end of this method.
                ErrorsContainer.SetErrors(propertyInfo.Name, propertyErrors);
            }

            return ErrorsContainer.HasErrors;
        }

        private bool TryValidateProperty(PropertyInfo propertyInfo, List<string> propertyErrors)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this) { MemberName = propertyInfo.Name };
            var propertyValue = propertyInfo.GetValue(this);

            // Validate the property
            bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

            if (results.Any())
            {
                propertyErrors.AddRange(results.Select(c => c.ErrorMessage));
            }

            return isValid;
        }

        public void MarkEntityAsClean()
        {
            IsDirty = false;
        }

    }
}
