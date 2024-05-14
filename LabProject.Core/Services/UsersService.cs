using LabProject.Database.Dtos.Request;
using LabProject.Database.Entities;
using LabProject.Database.Repositories;

namespace LabProject.Core.Services
{
    public class UsersService
    {
        public AuthService authService { get; set; }
        public UsersRepository usersRepository { get; set; }
        public UsersService(
            AuthService authService,
            UsersRepository usersRepository)
        {
            this.authService = authService;
            this.usersRepository = usersRepository;
        }

        public void Register(RegisterRequest registerData)
        {
            if (registerData == null)
            {
                return;
            }

            var salt = authService.GenerateSalt();
            var hashedPassword = authService.HashPassword(registerData.Password, salt);

            var user = new User();
            user.FirstName = registerData.FirstName;
            user.LastName = registerData.LastName;
            user.Email = registerData.Email;
            user.Password = hashedPassword;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.DateCreated = DateTime.UtcNow;

            usersRepository.Add(user);
        }

        public string Login(LoginRequest payload)
        {
            var user = usersRepository.GetByEmail(payload.Email);

            if (authService.HashPassword(payload.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = GetRole(user);

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }         
        }

        private string GetRole(User user)
        {
            if (user.Email == "administrator@cst.ro")
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }
    }
}
