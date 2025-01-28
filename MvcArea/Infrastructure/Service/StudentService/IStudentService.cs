using Domain.Entities;

namespace Infrastructure.Service.StudentService;

public interface IStudentService
{
    public Task<List<Student>> Students();
    public Task<Student> StudentById(int id);
    public Task<string> CreateStudent(Student student);
    public Task<string> UpdateStudent(Student student);
    public Task<string> DeleteStudent(int id);
}