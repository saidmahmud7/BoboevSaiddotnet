class UserService
{
    //register
    public void RegisterUser(UserDto user)
    {
        string hashedPassword = ConvertToHashedPassword.HashPassword(user.Password);
        SaveUserToDatabase(user, hashedPassword);
        SendEmail.SendWelcomeEmail(user.Email);
        Log.LogUserRegistration(user.Username);
    }
    
    //Save to Databasa
    private void SaveUserToDatabase(UserDto user, string hashedPassword)
    {
        Console.WriteLine("User saved to database.");
    }
    
}