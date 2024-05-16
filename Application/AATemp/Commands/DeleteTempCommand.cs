using Application.AATemp.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AATemp.Commands
{
    public class DeleteTempCommand : IRequest<TempDto>
    {
        public int Id { get; set; }
    }
}
