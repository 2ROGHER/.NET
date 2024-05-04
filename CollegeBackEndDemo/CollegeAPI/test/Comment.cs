namespace CollegeAPI.test
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
