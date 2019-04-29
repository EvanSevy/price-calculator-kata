using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    public static class DecimalExtensions
    {
        public static decimal ToTwoDecimals(this decimal number)
        {
            return System.Math.Round(number, 2);
        }

        public static string FormatAsCurrency(this decimal number)
        {
            return $"${number}";
        }

        public static string FormatAsPercentage(this decimal number)
        {
            return $"{number * 100}%";
        }
    }
}
