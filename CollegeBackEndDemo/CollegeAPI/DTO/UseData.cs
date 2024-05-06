namespace CollegeAPI.dto
{
    public class UsersResponseData
    {

    }
    // Normalmente esas clases se tendrian en modulos separados.
    public class User
    {
        public string ? Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string? Title { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }

        
    }
    public class UseData
    {
        // aqui tenemos que implementar el coidog para los datos que vamos a devolver
        public User[]? Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }

    }
}
