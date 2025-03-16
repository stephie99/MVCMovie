using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Agile_Process_with_Agile.Models;

namespace MVC_Agile_Process_with_Agile.Data
{
    public class MVC_Agile_Process_with_AgileContext : DbContext
    {
        public MVC_Agile_Process_with_AgileContext(DbContextOptions<MVC_Agile_Process_with_AgileContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Agile_Process_with_Agile.Models.Movie> Movie { get; set; }
    }
}