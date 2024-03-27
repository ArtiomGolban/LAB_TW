using System.Linq;
using BikeRental.BusinessLogic.DataBase;
using BikeRental.Domain.Entities.User;

public class UserApi
{
    public ULoginData UserRegisterLogic(ULoginData data)
    {
        using (var context = new BikeContext())
        {
            if (context.Users.Any(u => u.Name == data.Username))
            {
                return new ULoginData { Status = false };
            }

            var newUser = new UserDBTable
            {
                Name = data.Username,
                Password = data.Password, // Remember to hash passwords in a real application
                Email = data.Email
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return new ULoginData { Status = true };
        }
    }

    public ULoginData UserLoginLogic(ULoginData data)
    {
        using (var context = new BikeContext())
        {
            var user = context.Users.FirstOrDefault(u => u.Name == data.Username && u.Password == data.Password);
            if (user == null)
            {
                return new ULoginData { Status = false };
            }
        }
        return new ULoginData { Status = true };
    }
}