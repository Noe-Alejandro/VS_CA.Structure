﻿using CA.Recipe.Application.Services.PortResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Interfaces
{
    public interface IDiscGateway
    {
        DiscDTO CreateDisc();
    }
}
