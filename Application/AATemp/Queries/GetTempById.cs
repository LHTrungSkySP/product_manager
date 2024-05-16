using Application.AATemp.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AATemp.Queries
{
    public class GetTempById : IRequest<TempDto>
    {
        public int Int { get; set; }
    }
}
