using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Expressions 
{
    [DataContract]
    public class Expression {
        public Expression() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ExpressionType expressionType { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string description { get; set; }
    }

    [DataContract]
    public class ExpressionValue {
        public ExpressionValue() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string value { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionValueId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ExpressionAttribute expressionAttribute { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ExpressionInfo expression { get; set; }
    }

    [DataContract]
    public class ExpressionInfo {
        public ExpressionInfo() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionName { get; set; }
    }

    [DataContract]
    public class ExpressionType {
        public ExpressionType() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionTypeName { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ExpressionAttribute[] expressionAttributes { get; set; }
    }

    [DataContract]
    public class ExpressionAttribute {
        public ExpressionAttribute() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionAttributeId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string expressionAttributeName { get; set; }
    }
}
