using System;

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

    public class BasicResponse<T> {
        public int statusCode { get; set; }
        public bool success { get; set; }
        public T body { get; set; }
    }

    public class BasicSuccessResponse {
        public int statusCode { get; set; }
        public bool success { get; set; }
    }

    public class BasicUpdatedResponse : BasicSuccessResponse {
        public bool updated { get; set; }
    }
}
