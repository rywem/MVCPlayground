using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class MarketForecasterV2 : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // Imagine Call to API to do some complex calculation
            return new MarketResult
            {
                MarketCondition = Models.MarketCondition.Volatile
            };
        }
    }


}
