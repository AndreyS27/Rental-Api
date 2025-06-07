using Microsoft.EntityFrameworkCore;

public class UserMutation
{
    public async Task<UpdateUserPayload> UpdateUser(
        int id,
        UserInput input,
        [Service] AppDbContext context,
        CancellationToken ct)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.id == id, ct);

        if (user == null)
        {
            return new UpdateUserPayload(false, null, "Пользователь не найден");
        }

        user.name = input.Name;
        user.email = input.Email;

        await context.SaveChangesAsync(ct);

        return new UpdateUserPayload(true, user, null);
    }
}

public class UpdateUserPayload
{
    public bool Success { get; set; }
    public User User { get; }
    public string ErrorMessage { get; }

    public UpdateUserPayload(bool success, User user, string errorMessage)
    {
        Success = success;
        User = user;
        ErrorMessage = errorMessage;
    }
}