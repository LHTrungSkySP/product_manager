using Application.AATemp.Commands;
using Application.AATemp.Dto;
using Application.Accounts.Commands;
using Application.Accounts.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AATemp.CommandHandlers
{
    public class UpdateTempCommandHandler : IRequestHandler<UpdateTempCommand, TempDto>
    {
        public Task<TempDto> Handle(UpdateTempCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
