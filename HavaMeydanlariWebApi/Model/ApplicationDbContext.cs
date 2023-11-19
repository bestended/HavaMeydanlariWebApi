using Microsoft.EntityFrameworkCore;

namespace HavaMeydanlariWebApi.Model
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }


        public DbSet<Firmalar> Firmalars { get; set; }

        public DbSet<HavaLimanlar> HavaLimanlars { get; set; }
        public DbSet<Personeller> Personellers { get; set; }
        public DbSet<Ucaklar> Ucaklars { get; set; }




    }
}
