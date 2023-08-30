using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

namespace AssetLayer.SDK.Users 
{
    public class UserRole {   
        public UserRole() { }
        // [JsonPropertyName("teamId")]
        public string teamId { get; set; }
        // [JsonPropertyName("role")]
        public string role { get; set; }
    }

    public class UserAlias { 
        public UserAlias() { }
        // [JsonPropertyName("userId")]
        public string UserId { get; set; }
        // [JsonPropertyName("handle")]
        public string Handle { get; set; }
    }
    public class User {
        public User() { }
        // [JsonPropertyName("userId")]
        public string userId { get; set; }
        // [JsonPropertyName("email")]
        public string email { get; set; }
        // [JsonPropertyName("handle")]
        public string handle { get; set; }
        // [JsonPropertyName("roles")]
        public List<UserRole> roles { get; set; }
        // [JsonPropertyName("createdAt")]
        public long createdAt { get; set; }
        // [JsonPropertyName("updatedAt")]
        public long updatedAt { get; set; }
        // [JsonPropertyName("name")]
        public string name { get; set; }
        // [JsonPropertyName("status")]
        public string status { get; set; }
    }
}
