using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.interfaces
{

    public interface IProductPriceHandler : ITax, IDiscountOrUpcDiscount, IDiscount, IUpcDiscount
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
    public interface ITax
    {
        IDiscountOrUpcDiscount CalculateTax();
        IProductPriceHandler GetResult();
    }
	public interface IDiscountOrUpcDiscount
    {
        IDiscount CalculateDiscount();
        IResult CalculateUpcDiscount();
        IProductPriceHandler GetResult();
    }
	// ############
	// Perhaps just force the order of fluent syntax, from Tax to UpcDiscount to Discount (and allow multiple discounts)
	// ############
	public interface IDiscount : IResult
    {
        IDiscount CalculateDiscount();
        IResult CalculateUpcDiscount();
        IProductPriceHandler GetResult();
    }
	public interface IUpcDiscount : IResult
    {
        IProductPriceHandler GetResult();
    }
	//interface IResult : IResult
	//{
	//    IResult CalculateUpcDiscount();
	//}
	public interface IResult
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
