using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class MarketForecaster : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // Imagine Call to API to do some complex calculation
            return new MarketResult
            {
                MarketCondition = Models.MarketCondition.StableUp
            };
        }
    }


}
