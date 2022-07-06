using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hotel.Application.Humans.Commands.DeleteHuman
{
    public class DeleteHumanCommand : IRequest
    {
        public Guid HumanId { get; set; }
    }
}
