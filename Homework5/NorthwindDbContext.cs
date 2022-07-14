using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffolding
{
    internal class NorthwindDbContext
    {
        private DbContextOptions options;

        public NorthwindDbContext(DbContextOptions options)
        {
            this.options = options;
        }

    }
}