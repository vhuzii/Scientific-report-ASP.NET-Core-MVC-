using ScientificReportData.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScientificReportData.Models
{
   public class ReportItem : IEntity<int>
   {
      [Key]
      [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
      public int Id { get; set; }

      public string Type { get; set; }
      public string Content { get; set; }
      public string User { get; set; }
   }
}
