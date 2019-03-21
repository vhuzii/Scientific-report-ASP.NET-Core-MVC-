using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Data.Models
{
    public enum Role
    {
        Teacher,
        DepartmentHead,
        Dean
    }

    public enum PublicationStatus
    {
        Published,
        Printed,
        InProgres,
        InReview
    }
}
