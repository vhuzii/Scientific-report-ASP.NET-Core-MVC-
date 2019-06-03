using Microsoft.EntityFrameworkCore;
using ScientificReportData;
using ScientificReportData.Models;
using ScientificReportData.Models.Responses;
using ScientificReportServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportServices
{
    public class DepWorkService : IDepWorkService
    {
        private readonly UnitOfWork _unitOfWork;

        public DepWorkService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAuthor(int depWorkId, string author)
        {
            var pub = _unitOfWork.DepartmentWorkRepository.Set.Include(p => p.Authors).FirstOrDefault(p => p.Id == depWorkId);
            var aut = _unitOfWork.AuthorRepository.Create(new Author { Name = author });
            pub.Authors.Add(aut);
            _unitOfWork.DepartmentWorkRepository.Update(pub);
        }

        public DepWorkViewModel SearchDepartmentWork(string searchParam, string author, string depName)
        {
            searchParam = searchParam ?? "";
            author = author ?? "";
            var args = searchParam.Split(" ");
            var publs = CreateDepWorkViewModel(depName);
            var resPubls = publs.DepWorks.Where(p => (args.Any(a => p.Topic.IndexOf(a) != -1)) && p.Department == depName);
            var resAuthors = resPubls.Where(p => p.Authors.Any(a => a.Name.Contains(author)));
            var res = new DepWorkViewModel
            {
                DepWorks = resAuthors?.ToList(),
                Authors = publs.Authors
            };
            return res;
        }

        public DepWorkViewModel CreateDepWorkViewModel(string depName)
        {
            var deps = _unitOfWork.DepartmentWorkRepository.Set.Include(c => c.Authors)?.ToList();
            var authors = _unitOfWork.UserRepository.GetAll().Where( u => u.Department == depName ).Select(a => a.Name)?.ToList();
            return new DepWorkViewModel
            {
                DepWorks = deps,
                Authors = authors
            };
        }
    }
}
