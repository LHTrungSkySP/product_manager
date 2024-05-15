using Application.AATemp.Commands;
using Application.AATemp.Dto;
using Application.Accounts.Commands;
using Application.Accounts.Dto;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AATemp.CommandHandlers
{
    public class UpdatePermissionCommandHandler: IRequestHandler<CreateTempCommand, TempDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdatePermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TempDto> Handle(CreateTempCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
