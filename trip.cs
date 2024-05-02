using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class Trip
{
    public int TripId { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
}

public class Booking
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int TripId { get; set; }
    public DateTime BookingDate { get; set; }
    public string Status { get; set; }
}

public class Payment
{
    public int PaymentId { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
}

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class TripSearchCriteria
{
    public string Destination { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
}

public interface IUserService
{
    Task<User> RegisterAsync(RegisterRequest model);
    Task<User> LoginAsync(LoginRequest model);
}

public interface ITripService
{
    Task<List<Trip>> SearchTripsAsync(TripSearchCriteria criteria);
    Task<Trip> GetTripDetailsAsync(int tripId);
}

public interface IBookingService
{
    Task<int> MakeBookingAsync(int userId, int tripId);
}

public interface IPaymentService
{
    Task<bool> ProcessPaymentAsync(int bookingId, decimal amount, string paymentMethod);
}

public class UserService : IUserService
{
    public Task<User> RegisterAsync(RegisterRequest model)
    {
        // Placeholder logic for user registration
        var newUser = new User
        {
            UserId = 1, 
            Username = model.Username,
            Email = model.Email,
            Password = model.Password
        };

        return Task.FromResult(newUser);
    }

    public Task<User> LoginAsync(LoginRequest model)
    {
        // Placeholder logic for user login
        var user = new User
        {
            UserId = 1, 
            Username = model.Username,
            Email = "user@example.com", 
          Password = "hashed_password"
        };

        // Check if the provided credentials match the user record
        if (model.Username == user.Username && model.Password == user.Password)
        {
            return Task.FromResult(user);
        }
        else
        {
            throw new Exception("Invalid username or password");
        }
    }
}

public class TripService : ITripService
{
    public Task<List<Trip>> SearchTripsAsync(TripSearchCriteria criteria)
    {
        // Placeholder logic for trip search
        var trips = new List<Trip>
        {
            new Trip { TripId = 1, Destination = "Paris", DepartureDate = DateTime.Today.AddDays(30), Duration = 7, Price = 1000 },
            new Trip { TripId = 2, Destination = "New York", DepartureDate = DateTime.Today.AddDays(45), Duration = 5, Price = 1200 },
            new Trip { TripId = 3, Destination = "Tokyo", DepartureDate = DateTime.Today.AddDays(60), Duration = 10, Price = 1500 }
        };

        return Task.FromResult(trips);
    }

    public Task<Trip> GetTripDetailsAsync(int tripId)
    {
        // Placeholder logic for retrieving trip details
        var trip = new Trip
        {
            TripId = tripId,
            Destination = "Paris",
            DepartureDate = DateTime.Today.AddDays(30),
            Duration = 7,
            Price = 1000
            
        };

        return Task.FromResult(trip);
    }
}

public class BookingService : IBookingService
{
    public Task<int> MakeBookingAsync(int userId, int tripId)
    {
        // Placeholder logic for making a booking
        int bookingId = 123;
        return Task.FromResult(bookingId);
    }
}

public class PaymentService : IPaymentService
{
    public Task<bool> ProcessPaymentAsync(int bookingId, decimal amount, string paymentMethod)
    {
        // Placeholder logic for processing payment
      s
        bool isSuccess = true;
        return Task.FromResult(isSuccess);
    }
}

public class AuthController
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    public Task<User> Register(RegisterRequest model)
    {
        return _userService.RegisterAsync(model);
    }

    public Task<User> Login(LoginRequest model)
    {
        return _userService.LoginAsync(model);
    }
}

public class TripsController
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    public Task<List<Trip>> SearchTrips(TripSearchCriteria criteria)
    {
        return _tripService.SearchTripsAsync(criteria);
    }

    public Task<Trip> GetTripDetails(int tripId)
    {
        return _tripService.GetTripDetailsAsync(tripId);
    }
}

public class BookingsController
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<int> MakeBooking(int userId, int tripId)
    {
        return _bookingService.MakeBookingAsync(userId, tripId);
    }
}

public class PaymentsController
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public Task<bool> ProcessPayment(int bookingId, decimal amount, string paymentMethod)
    {
        return _paymentService.ProcessPaymentAsync(bookingId, amount, paymentMethod);
    }
}
