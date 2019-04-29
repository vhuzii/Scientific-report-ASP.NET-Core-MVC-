using Microsoft.AspNetCore.Mvc;
using ScientificReportData;
using ScientificReportData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificReport.Components.PublicationComp
{
    [ViewComponent]
    public class PublicationComponent : ViewComponent
    {
        public UnitOfWork _unitOfWork;

        public PublicationComponent(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("PublicationCreate"));
        }
    }
}
