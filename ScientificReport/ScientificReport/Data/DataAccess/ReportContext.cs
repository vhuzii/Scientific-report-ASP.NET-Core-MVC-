using Microsoft.EntityFrameworkCore;
using ScientificReport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ScientificReport.Data.DataAccess
{
    public class ReportContext : IdentityDbContext<User> {
	    public ReportContext(DbContextOptions<ReportContext> options)
		    : base(options) { }
       public virtual DbSet<Report> Reports { get; set; }
       public virtual DbSet<Publication> Publications { get; set; }
       public virtual DbSet<Author> Authors { get; set; }
       public virtual DbSet<DepartmentWork> DepartmentWorks { get; set; }
	}
}
