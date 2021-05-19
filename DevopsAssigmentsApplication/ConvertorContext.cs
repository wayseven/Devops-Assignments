using DevopsAssigmentsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DevopsAssigmentsApplication
{
    public class ConvertorContext : DbContext
    {
        public ConvertorContext(DbContextOptions<ConvertorContext> options)
            : base(options)
        {
        }

        public DbSet<ConversionModel> Conversions { get; set; }
    }
}
