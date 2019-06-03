using ScientificReportData.Interfaces;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportData
{
	public class UnitOfWork 
	{
		public readonly IRepository<Report, int> ReportRepository;
		public readonly IRepository<Author, int> AuthorRepository;
		public readonly IRepository<DepartmentWork, int> DepartmentWorkRepository;
		public readonly IRepository<Conference, int> ConferenceRepository;
		public readonly IRepository<Grant, int> GrantRepository;
		public readonly IRepository<ReportItem, int> ReportItemRepository;
		public readonly IRepository<Publication, int> PublicationRepository;
        public readonly IRepository<UserConference, int> UserConferenceRepository;
        public readonly IRepository<User, string> UserRepository;
        public readonly IRepository<DepartmentWorkIntro, int> DepartmentWorkTopicRepository;
        public readonly IRepository<ConferenceComments, int> ConferensCommentsRepository;
        public UnitOfWork(IRepository<Report, int> reportRepository,
			IRepository<Author, int> authorRepository,
			IRepository<DepartmentWork, int> departmentWorkRepository,
			IRepository<Conference, int> conferenceRepository,
			IRepository<Grant, int> grantRepository,
			IRepository<ReportItem, int> reportItemRepository,
			IRepository<Publication, int> publicationRepository,
			IRepository<UserConference, int> userConferenceRepository,
			IRepository<User, string> userRepository,
			IRepository<DepartmentWorkIntro, int> departmentWorkTopicRepository,
            IRepository<ConferenceComments, int> ConferensCommentsRepository) 
		{
			this.ReportRepository = reportRepository;
			this.AuthorRepository = authorRepository;
			this.DepartmentWorkRepository = departmentWorkRepository;
			this.ConferenceRepository = conferenceRepository;
			this.GrantRepository = grantRepository;
			this.PublicationRepository = publicationRepository;
		    this.UserConferenceRepository = userConferenceRepository;
		    this.ReportItemRepository = reportItemRepository;
		    this.UserRepository = userRepository;
		    this.DepartmentWorkTopicRepository = departmentWorkTopicRepository;
            this.ConferensCommentsRepository = ConferensCommentsRepository;

        }

        public Author GetAuthorByName(string name)
        {
            return AuthorRepository.GetAll().FirstOrDefault(a => a.Name == name);
        }
    }
}
