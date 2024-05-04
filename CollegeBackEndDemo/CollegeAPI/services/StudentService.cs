using CollegeAPI.Models.DataModels;

namespace CollegeAPI.services
{
    public class StudentService : IStudentService
    {
        public IEnumerable<Student> GetAllStudentsWithCourses()
        {
            //TODO: implement service 
            return null;
        }

        public IEnumerable<Student> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
