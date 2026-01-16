using GaraApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GaraApp.DAL
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(GaraDbContext context) : base(context) { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _db.FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _db.AnyAsync(u => u.Username == username);
        }
    }
}
