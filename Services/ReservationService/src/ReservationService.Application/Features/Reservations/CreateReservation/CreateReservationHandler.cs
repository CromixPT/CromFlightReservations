using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Ardalis.GuardClauses;

namespace ReservationService.Application.Features.Reservations.CreateReservation;

public class CreateReservationHandler : IRequestHandler<ReservationRequest, int>
{
    public int Coount { get; set; }

    public CreateReservationHandler(int coount)
    {
        Coount = coount;

    }

    public async Task<int> Handle(ReservationRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.DepartureCity))
            throw new ArgumentException("Invalid Parameter Departure City");

        //throw new NotImplementedException();
        Coount++;
        return await Task.FromResult(Coount);
    }
}

public class ReservationRequest : IRequest<int>
{
    public string? DepartureCity { get; set; }
    public string? DestinationCity { get; set; }
    public DateOnly? Date { get; set; }

}

// public class ExtensionMethods
// {
//     public static IsValid(this ReservationRequest request)
//     {
//         return request switch
//         {
//             request.Date DateTime.is
//             _ => true
//         };
//     }
// }