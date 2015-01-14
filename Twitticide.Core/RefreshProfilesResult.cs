namespace Twitticide
{
    public class RefreshProfilesResult
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public int ProfilesRefreshedCount { get; set; }
    }
}