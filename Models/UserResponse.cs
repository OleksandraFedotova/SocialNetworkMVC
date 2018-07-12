namespace SocialNetworkMVC.Models
{
    public class UserResponse
    {
        public Post TheLatestPost { get; set; }
        public Post MostPopularPostWithLikes { get; set; }
        public Post MostPopularPostWithComments { get; set; }
        public int QuantityOfNotDoneTodos { get; set; }
        public int QuantityComentsAtLastPost { get; set; }
    }

}
