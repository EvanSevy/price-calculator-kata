using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01
{
    public static class DecimalExtensions
    {
        public static decimal DecimalPlaces(this decimal number, int decimalPlaces)
        {
            return System.Math.Round(number, decimalPlaces);
        }
        public static decimal ToPercentage(this decimal number, int decimalPlaces = 1)
        {
            return (number * 100.0m).DecimalPlaces(decimalPlaces);
        }

        public static string CurrencyStr(this decimal number)
        {
            return $"${number}";
        }
        public static string PercentageStr(this decimal number)
        {
            return $"{number}%";
        }
    }
}
