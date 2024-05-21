using Application.AATemp.Commands;
using Application.AATemp.Dto;
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
    public class UpdateAssignPermissionCommandHandler : IRequestHandler<UpdateTempCommand, TempDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public UpdateAssignPermissionCommandHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<TempDto> Handle(UpdateTempCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
