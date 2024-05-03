using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceReference1;

namespace WebServicesAndEntityLinking.Controllers
{
    public class RecordsWCFController : Controller
    {
        Service1Client _service;
        public RecordsWCFController()
        {
            this._service = new Service1Client();
        }

        // GET: RecordsWCFController
        public async Task<IActionResult> Index()
        {
            var record = await _service.GetAllRecordAsync();

            return View(record.ToList<Record>());
        }
        [HttpGet("RecordsWCF/Index/Search")]
        public async Task<IActionResult> Index(string searchString)
        {
            var records = await _service.GetRecordAsync(searchString);
            return View(records.ToList());
        }


        // GET: RecordsWCFController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecordsWCFController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age")] ServiceReference1.Record @record)
        {
            if (ModelState.IsValid)
            {
                await _service.InsertRecordAsync(@record);
                return RedirectToAction(nameof(Index));
            }
            return View(@record);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteByName(string searchString)
        {
            if (searchString == null )
            {
                return NotFound();
            }

            var record = await _service.DeleteRecordByNameAsync(searchString);
            if (!record)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: RecordsWCFController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var @record = await _service.GetRecordByIdAsync(id);
            return View(@record);
        }

        // POST: RecordsWCFController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {

            var @record = await _service.FindByIdAsync(id);
            if (@record != null)
            {
                await _service.DeleteRecordAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
