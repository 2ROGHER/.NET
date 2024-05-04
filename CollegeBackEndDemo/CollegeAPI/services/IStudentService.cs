using CollegeAPI.Models.DataModels;

namespace CollegeAPI.services
{
    public interface IStudentService
    {
        // Get todos los estudiante aprobados 
        IEnumerable<Student> GetAllStudentsWithCourses();

        IEnumerable<Student> GetStudentsWithNoCourses();
    }
}
