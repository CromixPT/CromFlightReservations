using ReservationService.Application.Features.Reservations.CreateReservation;
using FluentValidation;
using FluentValidation.TestHelper;

namespace ReservationService.Application.UnitTests.Reservations;

public class CreateReservationRequestValidatorTests
{
    private readonly ReservationRequestValidator _validator;

    public CreateReservationRequestValidatorTests()
    {
        _validator = new ReservationRequestValidator();
    }

    [Theory]
    [InlineData(null)]
    public void Should_throw_exception_when_date_is_null(DateOnly? date)
    {
        var request = new ReservationRequest()
        {
            Date = date
        };

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(request => request.Date);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Should_throw_exception_when_destination_city_is_invalid(string? destinationCity)
    {
        var request = new ReservationRequest()
        {
            DestinationCity = destinationCity
        };
        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(request => request.DestinationCity);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Should_throw_exception_when_departure_city_is_invalid(string? departureCity)
    {
        var request = new ReservationRequest()
        {
            DepartureCity = departureCity
        };
        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(request => request.DepartureCity);
    }
}