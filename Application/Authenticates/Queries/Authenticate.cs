using Application.Authenticates.Dto;
using Azure.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authenticates.Queries
{
    public class Authenticate: IRequest<AuthenticateDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
