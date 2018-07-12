using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SocialNetworkMVC.Models
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }


        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Todo> Todos { get; set; }
        public Address Address { get; set; }
    }
}
