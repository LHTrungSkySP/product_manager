using Application.AATemp.Commands;
using Application.AATemp.Dto;
using AutoMapper;
using Infrastructure;
using MediatR;

namespace Application.AATemp.CommandHandlers
{
    public class CreateTempCommandHandler : IRequestHandler<CreateTempCommand, TempDto>
    {
        private BanHangContext _context;
        private readonly IMapper _mapper;

        public CreateTempCommandHandler(BanHangContext context, IMapper mapper)
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
