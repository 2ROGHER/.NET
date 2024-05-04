namespace CollegeAPI.Models
{
    public class UserTokens
    {
        public string Token { get; set; } // permite emitiruntoken a la persona quien ha echo el login
        public string UserName { get; set; }
        public TimeSpan Validity { get; set; }
        public string RefreshToken { get; set; }
        public int Id { get; set; }
        public string EmailId { get; set; }
        public Guid GuidId { get; set; }
        public DateTime ExpireTime { get; set; }

    }
}
