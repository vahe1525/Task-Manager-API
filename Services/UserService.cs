using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Task_Manager_API.Controllers.UserController;
using System.Security.Cryptography;
using System.Text;
using Task_Manager_API.Models;
using Task_Manager_API.Data;

namespace Task_Manager_API.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterAsync(string username, string email, string password)
        {

            // Check for duplicates
            if (await _context.Users.AnyAsync(u => u.Username == username || u.Email == email))
                return false;

            // Hash password
            using var hmac = new HMACSHA512();
            var passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true; 
        }

    }
}
