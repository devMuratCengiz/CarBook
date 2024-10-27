using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class DeleteLocationCommand :IRequest
    {
        public int Id { get; set; }

        public DeleteLocationCommand(int id)
        {
            Id = id;
        }
    }
}
