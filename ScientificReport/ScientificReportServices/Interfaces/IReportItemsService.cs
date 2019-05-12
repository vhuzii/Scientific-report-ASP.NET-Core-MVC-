using ScientificReportData.Models;
using ScientificReportData.Models.Responses;

namespace ScientificReportServices
{
    public interface IReportItemsService
    {
        DepartmentWork AddDepartmentWork(DepartmentWork dw);
        Grant AddGrant(Grant gr);
        Publication AddPublication(CreatePublicationModel pb);
        ReportItem AddReportItem(ReportItem ri);
        PubliEditViewModel SearchPublications(string searchParam, string author);
        void AddAuthor(int pubId, string author);
        Author GetUserAsAuthor(string usename);
    }
}