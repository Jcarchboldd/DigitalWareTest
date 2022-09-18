using Microsoft.EntityFrameworkCore;

namespace DigitalWareTestAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
         : base(options)
        {
        }


    }
}
