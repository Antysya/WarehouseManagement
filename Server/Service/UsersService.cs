using DataModel;
using Microsoft.AspNetCore.Mvc;
using Server.Auth;
using Server.Repositories;
using Server.Repositories.Interfaces;

namespace Server.Service
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IJwtProvider jwtProvider, IUsersRepository usersRepository, IPasswordHasher passwordHasher)
        {
            _jwtProvider = jwtProvider;
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task Register(string login, string password, int role)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            var user = Users.Create(login, hashedPassword, role);
            await _usersRepository.Add(user);
        }

        public async Task<string> Login (string login, string password)
        {
            var user = await _usersRepository.GetByLogin(login);
            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Ошибка авторизации");
            }

            var token = _jwtProvider.GenerateToken(user);
            return token;
        }

        public async Task<IEnumerable<Users>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _usersRepository.GetAll(cancellationToken);
        }

        public async Task UpdateUser(Users user, CancellationToken cancellationToken)
        {
            await _usersRepository.Update(user, cancellationToken);
        }
    }
}
