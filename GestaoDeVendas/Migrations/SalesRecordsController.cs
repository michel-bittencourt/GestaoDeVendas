using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoDeVendas.Data;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Migrations
{
    public class SalesRecordsController : Controller
    {
        private readonly GestaoDeVendasContext _context;

        public SalesRecordsController(GestaoDeVendasContext context)
        {
            _context = context;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
              return _context.SalesRecord != null ? 
                          View(await _context.SalesRecord.ToListAsync()) :
                          Problem("Entity set 'GestaoDeVendasContext.SalesRecord'  is null.");
        }

        // GET: SalesRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // GET: SalesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecord);
        }

        // GET: SalesRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord.FindAsync(id);
            if (salesRecord == null)
            {
                return NotFound();
            }
            return View(salesRecord);
        }

        // POST: SalesRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Status")] SalesRecord salesRecord)
        {
            if (id != salesRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(salesRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecord);
        }

        // GET: SalesRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesRecord == null)
            {
                return NotFound();
            }

            var salesRecord = await _context.SalesRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesRecord == null)
            {
                return NotFound();
            }

            return View(salesRecord);
        }

        // POST: SalesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesRecord == null)
            {
                return Problem("Entity set 'GestaoDeVendasContext.SalesRecord'  is null.");
            }
            var salesRecord = await _context.SalesRecord.FindAsync(id);
            if (salesRecord != null)
            {
                _context.SalesRecord.Remove(salesRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
          return (_context.SalesRecord?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
