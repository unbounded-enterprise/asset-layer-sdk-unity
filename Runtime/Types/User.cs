using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Users 
{
    [DataContract]
    public class UserRole {   
        public UserRole() { }
        // [JsonPropertyName("teamId")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string teamId { get; set; }
        // [JsonPropertyName("role")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string role { get; set; }
    }

    [DataContract]
    public class UserAlias { 
        public UserAlias() { }
        // [JsonPropertyName("userId")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string UserId { get; set; }
        // [JsonPropertyName("handle")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string Handle { get; set; }
    }
    [DataContract]
    public class User {
        public User() { }
        // [JsonPropertyName("userId")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string userId { get; set; }
        // [JsonPropertyName("email")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string email { get; set; }
        // [JsonPropertyName("handle")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string handle { get; set; }
        // [JsonPropertyName("roles")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<UserRole> roles { get; set; }
        // [JsonPropertyName("createdAt")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("name")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string name { get; set; }
        // [JsonPropertyName("status")]
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string status { get; set; }
    }
}
