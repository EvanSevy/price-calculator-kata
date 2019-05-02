using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.interfaces
{

    interface IProductPriceHandler : ITax, IDiscountOrUpcDiscount, IDiscount, IUpcDiscount
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
    }
    interface ITax
    {
        IDiscountOrUpcDiscount CalculateTax();
        IProductPriceHandler GetResult();
    }
    interface IDiscountOrUpcDiscount
    {
        IUpcDiscount CalculateDiscount();
        IDiscount CalculateUpcDiscount();
        IProductPriceHandler GetResult();
    }
    interface IDiscount : IResult
    {
        IUpcDiscount CalculateDiscount();
    }
    interface IUpcDiscount : IResult
    {
        IResult CalculateUpcDiscount();
    }
    //interface IThenDiscount : IResult
    //{
    //    IResult CalculateDiscount();
    //}
    //interface IThenUpcDiscount : IResult
    //{
    //    IResult CalculateUpcDiscount();
    //}
    interface IResult
    {
        IProductPriceHandler GetResult();
    }
    // ####### OLD #######
    //interface ITaxOrDiscountOrUpcDiscount
    //{
    //    IDiscountOrUpcDiscount CalculateTax();
    //    ITaxOrUpcDiscount CalculateDiscount();
    //    ITaxOrDiscount CalculateUpcDiscount();

    //    IProductPriceHandler GetResult();
    //}
    //interface ITaxOrDiscount
    //{
    //    IDiscountOrUpcDiscount CalculateTax();

    //    ITaxOrUpcDiscount CalculateDiscount();

    //    IProductPriceHandler GetResult();
    //}
    //interface IDiscountOrUpcDiscount
    //{
    //    ITaxOrUpcDiscount CalculateDiscount();
    //    ITaxOrDiscount CalculateUpcDiscount();
    //    IProductPriceHandler GetResult();
    //}
    //interface ITaxOrUpcDiscount
    //{
    //    IDiscountOrUpcDiscount CalculateTax();
    //    ITaxOrDiscount CalculateUpcDiscount();
    //    IProductPriceHandler GetResult();
    //}

}
