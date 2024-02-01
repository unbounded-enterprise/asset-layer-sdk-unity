using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
using AssetLayer.SDK.Collections;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Users 
{
    [DataContract]
    public class UserRole {   
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
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
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
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
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
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
    public class GetUserCollectionsProps { 
        public GetUserCollectionsProps() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDeactivated { get; set; } 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? includeDrafts { get; set; }
    }
    [DataContract]
    public class UserCollectionsProps : GetUserCollectionsProps { 
        public UserCollectionsProps() : base() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool? idOnly { get; set; } 
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
    public class GetUserResponse : BasicResponse<GetUserResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserResponse() : base() { }
    }
    [DataContract]
    public class GetUserResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public User user { get; set; } 
    }
    [DataContract]
    public class GetUserCollectionsResponse : BasicResponse<GetUserCollectionsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserCollectionsResponse() : base() { }
    }
    [DataContract]
    public class GetUserCollectionsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserCollectionsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<Collection> collections { get; set; } 
    }
    [DataContract]
    public class GetUserCollectionIdsResponse : BasicResponse<GetUserCollectionIdsResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserCollectionIdsResponse() : base() { }
    }
    [DataContract]
    public class GetUserCollectionIdsResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetUserCollectionIdsResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public List<string> collections { get; set; } 
    }
    [DataContract]
    public class GetOTPResponse : BasicResponse<GetOTPResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetOTPResponse() : base() { }
    }
    [DataContract]
    public class GetOTPResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public GetOTPResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string otp { get; set; } 
    }
    [DataContract]
    public class RegisterUserResponse : BasicResponse<RegisterUserResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public RegisterUserResponse() : base() { }
    }
    [DataContract]
    public class RegisterUserResponseBody {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
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
        public delegate Task<GetUserResponse> GetUser(Dictionary<string, string> headers = null);
        public delegate Task<(GetUserCollectionsResponse, GetUserCollectionIdsResponse)> Collections(UserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserCollectionsResponse> GetUserCollections(GetUserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetUserCollectionIdsResponse> GetUserCollectionIds(GetUserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<(GetOTPResponse, RegisterUserResponse)> Register(RegisterUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<GetOTPResponse> GetOTP(Dictionary<string, string> headers = null);
        public delegate Task<RegisterUserResponse> RegisterDid(RegisterDidProps props, Dictionary<string, string> headers = null);
    }

    public class UsersRawHandlers {
        public UsersRawDelegates.GetUser GetUser;
        public UsersRawDelegates.Collections Collections;
        public UsersRawDelegates.GetUserCollections GetUserCollections;
        public UsersRawDelegates.GetUserCollectionIds GetUserCollectionIds;
        public UsersRawDelegates.Register Register;
        public UsersRawDelegates.GetOTP GetOTP;
        public UsersRawDelegates.RegisterDid RegisterDid;
    }

    public class UsersSafeDelegates {
        public delegate Task<BasicResult<User>> GetUser(Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(List<Collection>, List<string>)>> Collections(UserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<Collection>>> GetUserCollections(GetUserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<List<string>>> GetUserCollectionIds(GetUserCollectionsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<(string, RegisterUserResponseBody)>> Register(RegisterUserProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> GetOTP(Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<RegisterUserResponseBody>> RegisterDid(RegisterDidProps props, Dictionary<string, string> headers = null);
    }

    public class UsersSafeHandlers {
        public UsersSafeDelegates.GetUser GetUser;
        public UsersSafeDelegates.Collections Collections;
        public UsersSafeDelegates.GetUserCollections GetUserCollections;
        public UsersSafeDelegates.GetUserCollectionIds GetUserCollectionIds;
        public UsersSafeDelegates.Register Register;
        public UsersSafeDelegates.GetOTP GetOTP;
        public UsersSafeDelegates.RegisterDid RegisterDid;
    }
}
