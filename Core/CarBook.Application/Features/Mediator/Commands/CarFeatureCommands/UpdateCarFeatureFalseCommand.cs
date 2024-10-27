using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureFalseCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureFalseCommand(int id)
        {
            Id = id;
        }
    }
}
