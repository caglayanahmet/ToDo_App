using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ToDo_App.ViewModels
{
    public class FutureDateTime:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid= DateTime.TryParseExact(Convert.ToString(value), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);
            return (isValid && dateTime>=DateTime.Today);
        }
    }
}