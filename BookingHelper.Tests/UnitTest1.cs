using Excercise1;
using Excercise1.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingHelper.Tests
{
    public class Tests
    {
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,6,20),
                    DepartureDate = new DateTime(2021,6,22),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 7, 22),
                DepartureDate = new DateTime(2021, 7, 25),
            }, repository.Object);
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,25),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 7, 22),
                DepartureDate = new DateTime(2021, 7, 25),
            }, repository.Object);
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,25),
                    Status = "Cancelled",
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking(), repository.Object);
            Assert.That(result, Is.Empty);
        }

            [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleAnExistingBooking_ReturnExistingBookingReference()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,25),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 8, 22),
                DepartureDate = new DateTime(2021, 8, 27),
            }, repository.Object);
            Assert.That(result, Is.EqualTo("Lam"));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,28),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 8, 19),
                DepartureDate = new DateTime(2021, 8, 27),
            }, repository.Object);
            Assert.That(result, Is.EqualTo("Lam"));
        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,25),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 8, 19),
                DepartureDate = new DateTime(2021, 8, 27),
            }, repository.Object);
            Assert.That(result, Is.EqualTo("Lam"));
        }
        [Test]

        public void BookingStartsInTheMiddleAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(x => x.GetBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2021,8,20),
                    DepartureDate = new DateTime(2021,8,28),
                    Reference = "Lam",
                }
            }.AsQueryable());
            var result = BookingHelper.OverlappingBookingExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2021, 8, 19),
                DepartureDate = new DateTime(2021, 8, 27),
            }, repository.Object);
            Assert.That(result, Is.EqualTo("Lam"));
        }
    }
}