using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Expressions 
{
    [DataContract]
    public class Expression {
        public Expression() { }
        [Preserve][DataMember]
        public string slotId { get; set; }
        [Preserve][DataMember]
        public string expressionId { get; set; }
        [Preserve][DataMember]
        public string expressionName { get; set; }
        [Preserve][DataMember]
        public ExpressionType expressionType { get; set; }
        [Preserve][DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class ExpressionValue {
        public ExpressionValue() { }
        [Preserve][DataMember]
        public string value { get; set; }
        [Preserve][DataMember]
        public string expressionValueId { get; set; }
        [Preserve][DataMember]
        public ExpressionAttribute expressionAttribute { get; set; }
        [Preserve][DataMember]
        public ExpressionInfo expression { get; set; }
    }

    [DataContract]
    public class ExpressionInfo {
        public ExpressionInfo() { }
        [Preserve][DataMember]
        public string expressionId { get; set; }
        [Preserve][DataMember]
        public string expressionName { get; set; }
    }

    [DataContract]
    public class ExpressionType {
        public ExpressionType() { }
        [Preserve][DataMember]
        public string expressionTypeId { get; set; }
        [Preserve][DataMember]
        public string expressionTypeName { get; set; }
        [Preserve][DataMember]
        public ExpressionAttribute[] expressionAttributes { get; set; }
    }

    [DataContract]
    public class ExpressionAttribute {
        public ExpressionAttribute() { }
        [Preserve][DataMember]
        public string expressionAttributeId { get; set; }
        [Preserve][DataMember]
        public string expressionAttributeName { get; set; }
    }
}
