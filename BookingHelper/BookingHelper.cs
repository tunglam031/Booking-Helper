using Excercise1;
using Excercise1.Interfaces;
using System.Linq;

namespace BookingHelper
{
    public class BookingHelper
    {
        public static string OverlappingBookingExist(Booking booking, IBookingRepository bookingRepository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = bookingRepository.GetBookings(booking.Id);
            var overlappingBooking = bookings.FirstOrDefault(b => booking.ArrivalDate < b.DepartureDate && b.ArrivalDate < booking.DepartureDate);
            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }
}