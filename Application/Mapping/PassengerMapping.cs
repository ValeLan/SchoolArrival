using Domain.Entities;

namespace Application.Mapping
{
    public class PassengerMapping
    {
        public Passenger FromUserToPassenger(User user)
        {
            var passenger = new Passenger()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,

            };
            return passenger;
        }
    }
}
