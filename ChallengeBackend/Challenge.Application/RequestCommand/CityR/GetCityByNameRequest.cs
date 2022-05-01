﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Application.Response;
using MediatR;

namespace Challenge.Application.RequestCommand.CityR
{
    public class GetCityByNameRequest : IRequest<CityResponseBase>
    {
        public string Name { get; set; }
    }
}
