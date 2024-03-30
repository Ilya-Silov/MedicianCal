using Microsoft.EntityFrameworkCore;

using WebApplication1.Data.Entity;

namespace WebApplication1.Config
{
    public class MedicianContext: DbContext
    {
        private static MedicianContext _instance;

        public static MedicianContext Instance { get
            {
                if (_instance == null)
                { 
                _instance = new MedicianContext();
                }
                return _instance;
            }
            set => _instance = value;
        }

        public MedicianContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=hnt8.ru;Port=5432;Database=VueAxiosShit;UserID=postgres;Password=_RasulkotV2");
        }
       

        public DbSet<MedicalCard> Cards { get; set; }
    }
}
