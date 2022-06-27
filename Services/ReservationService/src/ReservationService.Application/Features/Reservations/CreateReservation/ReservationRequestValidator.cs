using FluentValidation;

namespace ReservationService.Application.Features.Reservations.CreateReservation;

public class ReservationRequestValidator : AbstractValidator<ReservationRequest>
{
    public ReservationRequestValidator()
    {
        RuleFor(r => r.Date).NotNull();
        RuleFor(r => r.DepartureCity).NotEmpty();
        RuleFor(r => r.DestinationCity).NotEmpty();
    }
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