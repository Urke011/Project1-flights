
namespace Flights.Domain.Entities
{
    public record Flight(
        Guid Id,
        string Airline,
        string Price,
        TimePlace Departure,
        TimePlace Arrival,
        int remainingNumberOfSeats
        )
    {
        public IList<Booking> Bookings = new List<Booking>();
    }
}



