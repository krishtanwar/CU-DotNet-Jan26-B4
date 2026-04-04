using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> _loanList = new List<Loan>()
        {
            new Loan
            {
                LoanId = 1,
                Borrowername="Krish",
                LenderName="Upkaar Malik",
                Amount=100000,
                IsSettled=true
            },
            new Loan
            {
                LoanId = 2,
                Borrowername="Harsh",
                LenderName="Krish",
                Amount=100000,
                IsSettled=false
            }
        };
        // GET: LoanController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan l)
        {
            try
            {
                _loanList.Add(l);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null||id==0) return NotFound();
            return View();
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan l)
        {
            try
            {
                _loanList.Remove(l);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
