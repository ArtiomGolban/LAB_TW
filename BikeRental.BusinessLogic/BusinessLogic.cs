using BikeRental.BusinessLogic.Interfaces;

namespace BikeRental.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}