﻿using BikeRental.BusinessLogic.Core;
using BikeRental.BusinessLogic.Interfaces;
using BikeRental.Domain.Entities.User;

namespace BikeRental.BusinessLogic
{
    public class SessionBL: UserApi, ISession
    {
        public ULoginData UserLogin(ULoginData userAuthLogic)
        {
            return UserLoginLogic(userAuthLogic);
        }

        public ULoginData UserRegister(ULoginData userAuthLogic)
        {
            return UserRegisterLogic(userAuthLogic);
        }
    }
}