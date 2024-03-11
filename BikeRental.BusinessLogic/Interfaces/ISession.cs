using BikeRental.Domain.Entities.User;

namespace BikeRental.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginData UserLogin(ULoginData data);
    }
}