using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WinterWood.Entities;
using WinterWood.Repository.Contracts;

namespace WinterWood.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private readonly IRepository<Invoice> _invoiceRepository;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public HomeController(){}

        public HomeController(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public ActionResult Invoice(string sortOrder, string filter, string searchString, int? page)
        {
            IEnumerable<Invoice> invoices = null;
            int pageSize = 3; int pageNumber = (page ?? 1);
            try
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortParm = sortOrder == "TaxPointDate" ? "date_desc" : "TaxPointDate";
                if (searchString != null)
                {
                    page = 1;
                }
                else { searchString = filter; }
                //searchString = "120.00";
                ViewBag.filter = searchString;
                invoices = _invoiceRepository.GetAllInvoices();
                if (!String.IsNullOrEmpty(searchString))
                {
                    invoices = _invoiceRepository.Search(i => i.Reference.ToLower().Contains(searchString.ToLower()) || i.Account.Name.ToLower().Contains(searchString.ToLower())).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        invoices = invoices.OrderByDescending(i => i.Account.Name);
                        break;
                    case "TaxPointDate":
                        invoices = invoices.OrderBy(i => i.TaxPointDate);
                        break;
                    case "date_desc":
                        invoices = invoices.OrderByDescending(i => i.TaxPointDate);
                        break;
                    default:
                        invoices = invoices.OrderBy(i => i.Account.Name);
                        break;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return View(invoices.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}