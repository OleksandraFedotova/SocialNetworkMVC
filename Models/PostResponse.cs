namespace SocialNetworkMVC.Models
{
    public class PostResponse
    {
        public Comment TheBiggestComment { get; set; }
        public Comment TheMostLikedComment { get; set; }
        public int QuantityOfNeededComment { get; set; }
    }
}
