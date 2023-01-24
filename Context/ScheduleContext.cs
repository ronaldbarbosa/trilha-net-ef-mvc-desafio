using Microsoft.EntityFrameworkCore;

namespace trilha_net_ef_mvc_desafio.Context
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }       
    }
}