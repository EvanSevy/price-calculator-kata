using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.interfaces
{

    interface IProductPriceHandler : ITaxOrDiscountOrUpcDiscount
    {
        Product Product { get; set; }
        decimal Tax { get; set; }
        decimal TaxResult { get; set; }
        decimal Discount { get; set; }
        decimal DiscountResult { get; set; }
        decimal DiscountForUpc { get; set; }
        decimal DiscountForUpcResult { get; set; }
        decimal Total { get; set; }
        AddedExpenses AddedExpenses { get; set; }
        void AddExpense(AddedExpense expense);
    }
    interface ITaxOrDiscountOrUpcDiscount
    {
        IDiscountOrUpcDiscount CalculateTax();
        ITaxOrUpcDiscount CalculateDiscount();
        ITaxOrDiscount CalculateUpcDiscount();

        IProductPriceHandler GetResult();
    }
    interface ITaxOrDiscount
    {
        IDiscountOrUpcDiscount CalculateTax();

        ITaxOrUpcDiscount CalculateDiscount();

        IProductPriceHandler GetResult();
    }
    interface IDiscountOrUpcDiscount
    {
        ITaxOrUpcDiscount CalculateDiscount();
        ITaxOrDiscount CalculateUpcDiscount();
        IProductPriceHandler GetResult();
    }
    interface ITaxOrUpcDiscount
    {
        IDiscountOrUpcDiscount CalculateTax();
        ITaxOrDiscount CalculateUpcDiscount();
        IProductPriceHandler GetResult();
    }

}
