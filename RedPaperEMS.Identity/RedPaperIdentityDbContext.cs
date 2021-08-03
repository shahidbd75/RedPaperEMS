using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedPaperEMS.Identity.Models;

namespace RedPaperEMS.Identity
{
    public class RedPaperIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public RedPaperIdentityDbContext(DbContextOptions<RedPaperIdentityDbContext> options):base(options)
        {
            
        }
    }
}
