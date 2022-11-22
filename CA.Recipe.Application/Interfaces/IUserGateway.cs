﻿using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Interfaces
{
    public interface IUserGateway
    {
        UserResponseDB InsertUser(UserRequest request);
        void LoginUser();
        //Guardar receta
        //Calificar receta
    }
}
