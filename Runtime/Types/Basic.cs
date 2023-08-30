using System;
using System.Runtime.Serialization;

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
        [DataMember]
        public int statusCode { get; set; }
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public T body { get; set; }
    }

    [DataContract]
    public class BasicResponse2 {
        public BasicResponse2() { }
        [DataMember]
        public int statusCode { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [DataContract]
    public class BasicSuccessResponse {
        public BasicSuccessResponse() { }
        [DataMember]
        public int statusCode { get; set; }
        [DataMember]
        public bool success { get; set; }
    }

    [DataContract]
    public class BasicUpdatedResponse : BasicSuccessResponse {
        public BasicUpdatedResponse() : base() { }
        [DataMember]
        public bool updated { get; set; }
    }
}
