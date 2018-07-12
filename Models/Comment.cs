using Newtonsoft.Json;
using System;

namespace SocialNetworkMVC.Models
{ public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("userUd")]
        public int UserId { get; set; }

        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }


        public Post Post { get; set; }
    }
}
