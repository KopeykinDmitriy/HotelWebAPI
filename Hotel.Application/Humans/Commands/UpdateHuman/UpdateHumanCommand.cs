using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hotel.Application.Humans.Commands.UpdateHuman
{
    public class UpdateHumanCommand : IRequest
    {
        public Guid HumanId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
