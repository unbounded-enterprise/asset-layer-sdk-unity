using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Expressions 
{
    public class Expression {
        public string slotId { get; set; }
        public string expressionId { get; set; }
        public string expressionName { get; set; }
        public ExpressionType expressionType { get; set; }
        public string description { get; set; }
    }

    public class ExpressionValue {
        public string value { get; set; }  // URL to content
        public string expressionValueId { get; set; }
        public ExpressionAttribute expressionAttribute { get; set; }
        public ExpressionInfo expression { get; set; }
    }

    public class ExpressionInfo {
        public string expressionId { get; set; }
        public string expressionName { get; set; }
    }

    public class ExpressionType {
        public string expressionTypeId { get; set; }
        public string expressionTypeName { get; set; }
        public ExpressionAttribute[] expressionAttributes { get; set; }
    }

    public class ExpressionAttribute {
        public string expressionAttributeId { get; set; }
        public string expressionAttributeName { get; set; }
    }
}
