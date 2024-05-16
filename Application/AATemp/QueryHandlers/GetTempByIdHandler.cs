using Application.AATemp.Dto;
using Application.AATemp.Queries;
using AutoMapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AATemp.QueryHandlers
{
    public class GetAssignPermissionByIdHandler : IRequestHandler<GetTempById, TempDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public GetAssignPermissionByIdHandler(BanHangContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<TempDto> Handle(GetTempById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
