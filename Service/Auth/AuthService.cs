using AutoMapper;
using Data;
using Domain.DTO;
using Domain.Entities;
using System.Linq;

namespace Service.Auth
{
    public class AuthService : IAuthService
    {
        private ShopDbContext _db;
        private IMapper _mapper;
        private IJwtManager _jwtManager;

        public AuthService(ShopDbContext db, IMapper mapper, IJwtManager jwtManager)
        {
            _jwtManager = jwtManager;
            _db = db;
            _mapper = mapper;
        }
        public string LogIn(LoginDTO model)
        {
            var result = _db.Users.Any(t => t.Username == model.Username && t.Password == model.Password);
            if (result)
            {
                var response = _mapper.Map<UserDTO>(model);
                var token = _jwtManager.GenerateJSONWebToken(response);
                return token;
                
            }
            return "Login Failed";
        }

        public bool SignUp(LoginDTO body)
        {
            var map = _mapper.Map<User>(body);
            _db.Users.Add(map);
            return _db.SaveChanges() > 0;

        }
    }
}
