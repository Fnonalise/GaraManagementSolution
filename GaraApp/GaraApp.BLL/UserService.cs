using GaraApp.DAL;
using GaraApp.Entities;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GaraApp.BLL
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly GaraDbContext _context;

        public UserService()
        {
            _context = DbContextFactory.Create();
            _userRepository = new UserRepository(_context);
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    System.Diagnostics.Debug.WriteLine("Username or password is empty");
                    return null;
                }

                var user = await _userRepository.GetByUsernameAsync(username);
                if (user == null)
                {
                    System.Diagnostics.Debug.WriteLine($"User not found: {username}");
                    return null;
                }

                if (!user.IsActive)
                {
                    System.Diagnostics.Debug.WriteLine($"User is not active: {username}");
                    return null;
                }

                string hashedPassword = HashPassword(password);
                System.Diagnostics.Debug.WriteLine($"Input password hash: {hashedPassword}");
                System.Diagnostics.Debug.WriteLine($"Stored password hash: {user.Password}");
                System.Diagnostics.Debug.WriteLine($"Hashes match: {user.Password == hashedPassword}");

                if (user.Password != hashedPassword)
                {
                    System.Diagnostics.Debug.WriteLine("Password does not match");
                    return null;
                }

                System.Diagnostics.Debug.WriteLine($"Authentication successful for: {username}");
                return user;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in AuthenticateAsync: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (await _userRepository.UsernameExistsAsync(user.Username))
                throw new Exception("Tên ??ng nh?p ?ã t?n t?i!");

            user.Password = HashPassword(user.Password);
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            string hashedOldPassword = HashPassword(oldPassword);
            if (user.Password != hashedOldPassword)
                throw new Exception("M?t kh?u c? không ?úng!");

            user.Password = HashPassword(newPassword);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
