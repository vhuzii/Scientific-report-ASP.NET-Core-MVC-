using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Enums
{
    public static class EnumMappers
    {
        public static PublicationStatus GetPublicationStatus(string status)
        {
            switch (status)
            {
                case "Published":
                    return PublicationStatus.Published;
                case "Printed":
                    return PublicationStatus.Printed;
                case "InProgres":
                    return PublicationStatus.InProgres;
                case "InReview":
                    return PublicationStatus.InReview;
                default:
                    throw new ArgumentException("No such publication status");
            }
        }
    }
}