using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TallerMecanico.API.Datos;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Controllers
{
    public class ProcedimientosController : Controller
    {
        private readonly DataContext _context;

        public ProcedimientosController(DataContext context)
        {
            _context = context;
        }


        // GET: Procedimiento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedimientos.ToListAsync());
        }



        // GET: Procedimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(procedimiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este procedimiento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }

                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }


            return View(procedimiento);
        }

        // GET: TipoVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procedimiento procedimiento = await _context.Procedimientos.FindAsync(id);
            if (procedimiento == null)
            {
                return NotFound();
            }
            return View(procedimiento);
        }

        // POST: TipoVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Procedimiento procedimiento)
        {
            if (id != procedimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }

                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }


            }
            return View(procedimiento);
        }

        // GET: TipoVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Procedimiento procedimiento = await _context.Procedimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            _context.Procedimientos.Remove(procedimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Procedimiento/Delete/5



    }
}
