using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Validation
{
    internal class IPv4Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch(value.ToString(), @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "Bitte gib eine IPv4-Adresse ein.");
        }
    }


    public class ValidationRuleCollection : Collection<ValidationRule> { }

    public class ValidationExtension : MarkupExtension
    {
        private Binding binding;

        public ValidationExtension(Binding binding, ValidationRuleCollection validationRules)
        {
            this.binding = binding;

            foreach (var item in validationRules)
            {
                binding.ValidationRules.Add(item);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return binding.ProvideValue(serviceProvider);
        }
    }
}
