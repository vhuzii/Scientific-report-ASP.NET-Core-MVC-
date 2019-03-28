using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ScientificReport.Data.Enums;

namespace ScientificReport.Data.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override string Id { get; set; }

        public string Name { get; set; }

        public Role Role { get; set; }

        public DateTime Birthdate { get; set; }

        public string Graduation { get; set; }

        public DateTime GraduationDate { get; set; }

        public string Title { get; set; }

        public string Faculty { get; set; }

        public string Department { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Report> Reports { get; set; }

        public ICollection<Publication> Publications { get; set; }
    }
}
