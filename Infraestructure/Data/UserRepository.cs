//using ConsultaAlumnos.Infrastructure.Data;
//using Domain.Entities;
//using Domain.Interfaces;

//namespace Infraestructure.Data
//{
//    public class UserRepository : EfRepository<User>, IUserRepository
//    {
//        public UserRepository(TravelArrivalDbContext context) : base(context) { }
        
//        public User? Authenticate(string username, string password)
//        {
//            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.FullName == username && u.Password == password);
//            return userToAuthenticate;
//        }
//    }
//}
