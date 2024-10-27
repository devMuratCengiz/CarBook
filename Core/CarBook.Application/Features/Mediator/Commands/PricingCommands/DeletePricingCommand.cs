using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class DeletePricingCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePricingCommand(int id)
        {
            Id = id;
        }
    }
}
