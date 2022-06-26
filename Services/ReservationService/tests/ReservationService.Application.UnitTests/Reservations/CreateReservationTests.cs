using FluentAssertions;
using ReservationService.Application.Features.Reservations.CreateReservation;

namespace ReservationService.Application.UnitTests.Reservations;

public class CreateReservationTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task CreateReservation_NullDepartureCity_ShouldThrowValidationException(string? city)
    {

        var request = new ReservationRequest()
        {
            DepartureCity = city
        };
        var handler = new CreateReservationHandler(10);
        var cancellationToken = new CancellationTokenSource();

        Func<Task> act = () => handler.Handle(request, cancellationToken.Token);
        await act.Should().ThrowAsync<ArgumentException>();
    }
}