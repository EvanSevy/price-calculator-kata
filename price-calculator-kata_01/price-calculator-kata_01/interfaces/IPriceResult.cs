using System;
using System.Collections.Generic;
using System.Text;

namespace price_calculator_kata_01.interfaces
{
    interface IPriceResult
    {
        ITaxOrDiscount ForPriceResult();
    }
}
