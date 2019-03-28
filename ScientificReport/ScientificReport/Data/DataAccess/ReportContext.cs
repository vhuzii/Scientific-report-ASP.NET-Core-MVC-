using Microsoft.EntityFrameworkCore;
using ScientificReport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Data.DataAccess
{
    public class ReportContext : DbContext
    {
	    public ReportContext(DbContextOptions<ReportContext> options)
		    : base(options) { }
		public virtual DbSet<User> Users { get; set; }
       public virtual DbSet<Report> Reports { get; set; }
       public virtual DbSet<Publication> Publications { get; set; }
       public virtual DbSet<Author> Authors { get; set; }
	}
}
