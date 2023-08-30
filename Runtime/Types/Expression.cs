using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Expressions 
{
    [DataContract]
    public class Expression {
        [DataMember]
        public string slotId { get; set; }
        [DataMember]
        public string expressionId { get; set; }
        [DataMember]
        public string expressionName { get; set; }
        [DataMember]
        public ExpressionType expressionType { get; set; }
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class ExpressionValue {
        [DataMember]
        public string value { get; set; }
        [DataMember]
        public string expressionValueId { get; set; }
        [DataMember]
        public ExpressionAttribute expressionAttribute { get; set; }
        [DataMember]
        public ExpressionInfo expression { get; set; }
    }

    [DataContract]
    public class ExpressionInfo {
        [DataMember]
        public string expressionId { get; set; }
        [DataMember]
        public string expressionName { get; set; }
    }

    [DataContract]
    public class ExpressionType {
        [DataMember]
        public string expressionTypeId { get; set; }
        [DataMember]
        public string expressionTypeName { get; set; }
        [DataMember]
        public ExpressionAttribute[] expressionAttributes { get; set; }
    }

    [DataContract]
    public class ExpressionAttribute {
        [DataMember]
        public string expressionAttributeId { get; set; }
        [DataMember]
        public string expressionAttributeName { get; set; }
    }
}
