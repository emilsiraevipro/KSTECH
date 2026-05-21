using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aviaservice.Domain.Module
{
    public class Flight // Рейс
    {
        private readonly List<Seat> _seats = [];
        public Guid Id { get; private set; } // Id рйеса
        public string FlightNumber { get; private set; } = default!;
        public IReadOnlyList<Seat> Seats => _seats; // список мест
        public string Origin { get; private set; } = default!; // точка отправления
        public string Destination { get; private set; } = default!; // точка прибытия
        public DateTime Arrival { get; private set; } = default!; // дата отправления
        public DateTime Departure { get; private set; } = default!; // дата прибытия
        public Enum Status { get; private set; } = default!;
        public Flight() { } // for EF core
        public Flight(string flightnumber, string origin, string destination, DateTime arrival, DateTime departure)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                throw new Exception(origin);
            }
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new Exception(destination);
            }
            if (string.IsNullOrWhiteSpace(flightnumber))
            {
                throw new Exception(flightnumber);
            }
        }
        public void BookFlight(Guid flightid, Seat seatnumber)
        {
            //поправить//переделать
            _seats.Add(seatnumber);
        }
        public static Result<Flight> Create(string flightnumber, string origin, string destination, DateTime arrival, DateTime departure)
        {
            if (string.IsNullOrWhiteSpace(flightnumber))
                return Result.Failure<Flight>("Рейс не может быть без номера");
            if (string.IsNullOrWhiteSpace(origin))
                return Result.Failure<Flight>("Рейс не может быть без точки отправления");
            if (string.IsNullOrWhiteSpace(destination))
                return Result.Failure<Flight>("Рейс не может быть без точки назначения");
            Flight flight = new Flight(flightnumber, origin, destination, arrival, departure);
            return Result.Success(flight);
        }
    }
}
