using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SocialNetworkMVC.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }


        public User User { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
