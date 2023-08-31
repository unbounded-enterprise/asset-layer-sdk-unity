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
        [Preserve][DataMember]
        public string teamId { get; set; }
        // [JsonPropertyName("role")]
        [Preserve][DataMember]
        public string role { get; set; }
    }

    [DataContract]
    public class UserAlias { 
        public UserAlias() { }
        // [JsonPropertyName("userId")]
        [Preserve][DataMember]
        public string UserId { get; set; }
        // [JsonPropertyName("handle")]
        [Preserve][DataMember]
        public string Handle { get; set; }
    }
    [DataContract]
    public class User {
        public User() { }
        // [JsonPropertyName("userId")]
        [Preserve][DataMember]
        public string userId { get; set; }
        // [JsonPropertyName("email")]
        [Preserve][DataMember]
        public string email { get; set; }
        // [JsonPropertyName("handle")]
        [Preserve][DataMember]
        public string handle { get; set; }
        // [JsonPropertyName("roles")]
        [Preserve][DataMember]
        public List<UserRole> roles { get; set; }
        // [JsonPropertyName("createdAt")]
        [Preserve][DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        [Preserve][DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("name")]
        [Preserve][DataMember]
        public string name { get; set; }
        // [JsonPropertyName("status")]
        [Preserve][DataMember]
        public string status { get; set; }
    }
}
