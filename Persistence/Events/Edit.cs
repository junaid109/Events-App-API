using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Events
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string Category { get; set; }

            public DateTime? Date { get; set; }

            public string City { get; set; }

            public string Venue { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var newEvent = await _context.Events.FindAsync(request.id);

                if (newEvent == null)
                {
                    throw new Exception("Could not find the event");
                }

                newEvent.Title = request.Title ?? newEvent.Title;
                newEvent.Description = request.Description ?? newEvent.Description;
                newEvent.Category = request.Category ?? newEvent.Category;
                newEvent.Date = request.Date ?? newEvent.Date;
                newEvent.City = request.City ?? newEvent.City;
                newEvent.Venue = request.Venue ?? newEvent.Venue;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return Unit.Value;
                }

                throw new Exception("Problem saving changes");
            }
        }

    }
}
