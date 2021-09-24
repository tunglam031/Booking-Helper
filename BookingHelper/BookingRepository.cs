using Excercise1.Interfaces;
using System.Linq;

namespace Excercise1
{
    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetBookings(int id)
        {
            var unitOfWork = new UnitOfWork();
            var bookings = unitOfWork.Query<Booking>()
                                     .Where(b => b.Id != id && b.Status != "Cancelled");

            return bookings;
        }
    }
}