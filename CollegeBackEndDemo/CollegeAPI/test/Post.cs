namespace CollegeAPI.test
{
    public class Post
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public List<Comment> Comments { get; set; } // relationship with Comments entity
    }
}
