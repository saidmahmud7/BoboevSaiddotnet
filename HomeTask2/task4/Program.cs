

public class StudentRepository
{
    public virtual Student GetById(int id)
    {
        Console.WriteLine("get student from database.");
        return new Student { Id = id, Name = "Ahmad" };
    }

    public virtual void Add(Student student)
    {
        Console.WriteLine("Adding student to database.");
    }
}

// Cached Repository
public class CachedStudentRepository : StudentRepository
{
    private readonly Dictionary<int, Student> _cache = new();

    public override Student GetById(int id)
    {
        if (_cache.ContainsKey(id))
        {
            Console.WriteLine("Get student from cache.");
            return _cache[id];
        }

        var student = base.GetById(id);
        _cache[id] = student;
        return student;
    }

    public override void Add(Student student)
    {
        throw new NotImplementedException("Cannot add students to the cache!");
    }
}
