using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public int PickUpId { get; set; }
        public int DropOffId { get; set; }
        public int CarId { get; set; }
        public int Age { get; set; }
        public int LicenseYear { get; set; }
        public string Description { get; set; }
    }
}
