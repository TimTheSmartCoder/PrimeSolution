using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monitor.Domain.Entities;
using Monitor.Infrastructure.Repositories;
using Monitor.MVC.Models.View;

namespace Monitor.MVC.Controllers
{
    public class ViewController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ViewController(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var all = this.unitOfWork
                .Repository
                .Where<LogInformation>(x => x.HttpMethod.Equals("GET"))
                .ToList();

            var servicesLogInformation = this.unitOfWork
                .Repository
                .Where<LogInformation>(x => x.HttpMethod.Equals("GET"))
                .GroupBy(x => x.ServiceId)
                .ToList();
            
            var model = new ViewIndexModel(all, servicesLogInformation);

            return View(model);
        }
    }
}