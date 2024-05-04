namespace CollegeAPI.test
{
    public class Main
    {
        // Estos son importantes para implementar controlladores y solucionar controlladores mas complejos 
        // y mas sofisticados para nuestra API.

   
        public static void RelationLinq()
        {
            List<Post> posts = new List<Post>();
            {
                new Post()
                {
                    Id = 1,
                    Title = "Post 1",
                    Content = "Content 1",
                    Created = DateTime.Now,
                    Comments = new List<Comment>() { new Comment() { Id = 1, Body = "Body 1", Created = DateTime.Now, Title = "Title 1" }, new Comment() { Id = 2, Body = "Body 2", Created = DateTime.Now, Title = "Title 2" } },

                };
            };

            var commentsWithContent = posts.SelectMany(post => post.Comments, (post, comment) => new { post.Id, CommentContent = comment.Body });

        }
    }
}
