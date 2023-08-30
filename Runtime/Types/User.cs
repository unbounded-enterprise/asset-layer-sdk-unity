using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Users 
{
    [DataContract]
    public class UserRole {   
        public UserRole() { }
        // [JsonPropertyName("teamId")]
        [DataMember]
        public string teamId { get; set; }
        // [JsonPropertyName("role")]
        [DataMember]
        public string role { get; set; }
    }

    [DataContract]
    public class UserAlias { 
        public UserAlias() { }
        // [JsonPropertyName("userId")]
        [DataMember]
        public string UserId { get; set; }
        // [JsonPropertyName("handle")]
        [DataMember]
        public string Handle { get; set; }
    }
    [DataContract]
    public class User {
        public User() { }
        // [JsonPropertyName("userId")]
        [DataMember]
        public string userId { get; set; }
        // [JsonPropertyName("email")]
        [DataMember]
        public string email { get; set; }
        // [JsonPropertyName("handle")]
        [DataMember]
        public string handle { get; set; }
        // [JsonPropertyName("roles")]
        [DataMember]
        public List<UserRole> roles { get; set; }
        // [JsonPropertyName("createdAt")]
        [DataMember]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        [DataMember]
        public long updatedAt { get; set; }
        // [JsonPropertyName("name")]
        [DataMember]
        public string name { get; set; }
        // [JsonPropertyName("status")]
        [DataMember]
        public string status { get; set; }
    }
}
