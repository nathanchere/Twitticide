namespace Twitticide
{
    public class RefreshResult
    {
        public int NewFollowers { get; set; }
        public int NewFollowing { get; set; }
        public int NewUnfollowers { get; set; }
        public int NewUnfollowing { get; set; }
        public int TotalFollowers { get; set; }
        public int TotalFollowing { get; set; }

        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}