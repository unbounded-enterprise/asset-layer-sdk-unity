using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using AssetLayer.SDK;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Core.Base;
using AssetLayer.SDK.Utils;
using UnityEngine;

namespace AssetLayer.SDK.Core.Currencies
{
    public class CurrenciesHandler : BaseHandler
    {
        private static CurrenciesHandler _this;
        public CurrenciesHandler(AssetLayerConfig config = null) : base(config) { _this = this; }
        


        public object Raw = new {
            
        };

        public object Safe = new
        {
            
        };
    }
}
