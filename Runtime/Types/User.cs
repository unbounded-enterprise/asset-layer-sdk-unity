using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Users 
{
    [DataContract]
    public class UserRole {   
        public UserRole() { }

        // [JsonPropertyName("teamId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string teamId { get; set; }
        // [JsonPropertyName("role")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string role { get; set; }
    }

    [DataContract]
    public class UserAlias { 
        public UserAlias() { }

        // [JsonPropertyName("userId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string UserId { get; set; }
        // [JsonPropertyName("handle")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string Handle { get; set; }
    }
    [DataContract]
    public class User {
        public User() { }

        // [JsonPropertyName("userId")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string userId { get; set; }
        // [JsonPropertyName("email")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string email { get; set; }
        // [JsonPropertyName("handle")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string handle { get; set; }
        // [JsonPropertyName("roles")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<UserRole> roles { get; set; }
        // [JsonPropertyName("createdAt")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("name")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string name { get; set; }
        // [JsonPropertyName("status")]
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
    }

    [DataContract]
    public class UserLoginProps { 
        public UserLoginProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string didToken { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string registeredDidToken { get; set; } 
    }
    [DataContract]
    public class RegisterUserProps { 
        public RegisterUserProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string otp { get; set; }
    }
    [DataContract]
    public class RegisterDidProps { 
        public RegisterDidProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string otp { get; set; }
    }


    [DataContract]
    public class GetUserResponse : BasicResponse<GetUserResponseBody> { public GetUserResponse() : base() { } }
    [DataContract]
    public class GetUserResponseBody { 
        public GetUserResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public User user { get; set; } 
    }
    [DataContract]
    public class GetOTPResponse : BasicResponse<GetOTPResponseBody> { public GetOTPResponse() : base() { } }
    [DataContract]
    public class GetOTPResponseBody { 
        public GetOTPResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string otp { get; set; } 
    }
    [DataContract]
    public class RegisterUserResponse : BasicResponse<RegisterUserResponseBody> { public RegisterUserResponse() : base() { } }
    [DataContract]
    public class RegisterUserResponseBody {
        public RegisterUserResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string _id { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string email { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string handle { get; set; }
    }

    public class UsersRawDelegates {
        public delegate Task<GetUserResponse> GetUser(Dictionary<string, string> queryParams = null);
        public delegate Task<(GetOTPResponse, RegisterUserResponse)> Register(RegisterUserProps body, Dictionary<string, string> queryParams = null);
        public delegate Task<GetOTPResponse> GetOTP(Dictionary<string, string> queryParams = null);
        public delegate Task<RegisterUserResponse> RegisterDid(RegisterDidProps body, Dictionary<string, string> queryParams = null);
    }

    public class UsersRawHandlers {
        public UsersRawDelegates.GetUser GetUser;
        public UsersRawDelegates.Register Register;
        public UsersRawDelegates.GetOTP GetOTP;
        public UsersRawDelegates.RegisterDid RegisterDid;
    }

    public class UsersSafeDelegates {
        public delegate Task<BasicResult<User>> GetUser(Dictionary<string, string> queryParams = null);
        public delegate Task<BasicResult<(string, RegisterUserResponseBody)>> Register(RegisterUserProps body, Dictionary<string, string> queryParams = null);
        public delegate Task<BasicResult<string>> GetOTP(Dictionary<string, string> queryParams = null);
        public delegate Task<BasicResult<RegisterUserResponseBody>> RegisterDid(RegisterDidProps body, Dictionary<string, string> queryParams = null);
    }

    public class UsersSafeHandlers {
        public UsersSafeDelegates.GetUser GetUser;
        public UsersSafeDelegates.Register Register;
        public UsersSafeDelegates.GetOTP GetOTP;
        public UsersSafeDelegates.RegisterDid RegisterDid;
    }
}
