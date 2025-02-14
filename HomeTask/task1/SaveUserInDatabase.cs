public class SaveUserInDatabase(DataContext context)
{
    public async Task<bool> SaveToDatabase(User user)
    {
        context.Users.AddAsync(user);
        return await context.SaveChangesAsync() > 0;
    }
}