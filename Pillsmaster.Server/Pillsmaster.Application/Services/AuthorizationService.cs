using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Pillsmaster.Application.Common.Exceptions;
using Pillsmaster.Application.Interfaces;
using Pillsmaster.Application.ViewModels;
using Pillsmaster.Domain.Models;

namespace Pillsmaster.Application.Services
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        private readonly IConfiguration _configuration;

        public AuthorizationService(IPillsmasterDbContext dbContext, IConfiguration configuration) 
            : base(dbContext) => _configuration = configuration;

        public async Task<User> Register(UserViewModel userVm, CancellationToken cancellationToken)
        {
            var passwordData = await CreatePasswordHashAndSaltAsync(userVm.Password, cancellationToken);

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = userVm.Email,
                PasswordHash = passwordData.Item1,
                PasswordSalt = passwordData.Item2,
                UserDetails = new()
                {
                    Id = Guid.NewGuid(),
                    Name = userVm.UserDetails.Name,
                    Surname = userVm.UserDetails.Surname
                }
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user;
        }

        public  async Task<string> Login(UserViewModel userVm, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(
                user => user.Email
                    .Equals(userVm.Email.ToLower()), cancellationToken);

            if (user is null || 
                !await VerifyPasswordHashAsync(userVm.Password,
                    user.PasswordHash, 
                    user.PasswordSalt, 
                    cancellationToken))
            {
                throw new AuthorizationFailedException();
            }

            return CreateToken(user);
        }

        private async Task<(byte[], byte[])> CreatePasswordHashAndSaltAsync(string password, CancellationToken cancellationToken)
        {
            await using MemoryStream passwordMemoryStream = new(Encoding.UTF8.GetBytes(password));

            using var hmac = new HMACSHA512();

            var passwordHash = await hmac.ComputeHashAsync(passwordMemoryStream, cancellationToken);
            var passwordSalt = hmac.Key;

            return (passwordHash, passwordSalt);
        }

        private async Task<bool> VerifyPasswordHashAsync(string password, byte[] passwordHash, byte[] passwordSalt, CancellationToken cancellationToken)
        {
            await using MemoryStream passwordMemoryStream = new(Encoding.UTF8.GetBytes(password));

            using var hmac = new HMACSHA512(passwordSalt);

            var computedPasswordHash = await hmac.ComputeHashAsync(passwordMemoryStream, cancellationToken);

            return computedPasswordHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
