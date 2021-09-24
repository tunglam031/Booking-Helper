using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1.Interfaces
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings(int id);
    }
}
