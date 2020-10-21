﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ToDo_App.ViewModels
{
    public class FutureDateTime:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid= DateTime.TryParseExact(Convert.ToString(value), "yyyy-MM-dd", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime);
            return (isValid && dateTime>=DateTime.Now);
        }
    }
}