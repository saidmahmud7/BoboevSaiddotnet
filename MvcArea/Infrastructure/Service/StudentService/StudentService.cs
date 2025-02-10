using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.StudentService;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<List<Student>> Students()
    {
        return await context.Students.Include(s => s.Group).ToListAsync();
    }

    public async Task<Student> StudentById(int id)
    {
        var res = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        if (res == null) return null;
        return res;
    }

    public async Task<string> CreateStudent(Student student)
    {
        await context.Students.AddAsync(student);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Created Successfully";
    }

    public async Task<string> UpdateStudent(Student student)
    {
        var existing = await context.Students.FirstOrDefaultAsync(x => x.Id == student.Id);
        if (existing == null)
            return "Group not found";
        existing.Id = student.Id;
        existing.FirstName = student.FirstName;
        existing.LastName = student.LastName;
        existing.Age = student.Age;
        existing.Email = student.Email;
        existing.Phone = student.Phone;
        existing.Address = student.Address;
        existing.GroupId = student.GroupId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Updated Successfully";
    }

    public async Task<string> DeleteStudent(int id)
    {
        var existing = await context.Students.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return "Group not found";
        context.Students.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? "Internal Server Error"
            : "Deleted Successfully";
    }
}