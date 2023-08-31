using System;
using System.Runtime.Serialization;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Basic 
{
    public class BasicEmptyObject { }
    public class BasicError : Exception {
        public int status;

        public BasicError(string message, int status) : base(message) { 
            this.status = status; 
        }
    }

    public class BasicResult<T> {
        public T result { get; set; }
        public BasicError error { get; set; }
    }

    [DataContract]
    public class BasicResponse<T> {
        public BasicResponse() { }
        [Preserve][DataMember]
        public int statusCode { get; set; }
        [Preserve][DataMember]
        public bool success { get; set; }
        [Preserve][DataMember]
        public T body { get; set; }
    }

    [DataContract]
    public class BasicSuccessResponse {
        public BasicSuccessResponse() { }
        [Preserve][DataMember]
        public int statusCode { get; set; }
        [Preserve][DataMember]
        public bool success { get; set; }
    }

    [DataContract]
    public class BasicUpdatedResponse : BasicSuccessResponse {
        public BasicUpdatedResponse() : base() { }
        [Preserve][DataMember]
        public bool updated { get; set; }
    }
}
