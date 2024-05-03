using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServicesAndEntityLinking.Models;

namespace WebServicesAndEntityLinking.Data
{
    public class RecordContext : DbContext
    {
        public RecordContext (DbContextOptions<RecordContext> options)
            : base(options)
        {
        }

        public DbSet<WebServicesAndEntityLinking.Models.Record> Record { get; set; } = default!;
    }
}
