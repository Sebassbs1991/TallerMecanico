using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TallerMecanico.API.Datos;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Controllers
{
    public class TipoVehiculosController : Controller
    {
        private readonly DataContext _context;

        public TipoVehiculosController(DataContext context)
        {
            _context = context;
        }


        // GET: TipoVehiculo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoVehiculos.ToListAsync());
        }



        // GET: TipoVehiculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoVehiculo tipoVehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tipoVehiculo);
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


            return View(tipoVehiculo);
        }

        // GET: TipoVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoVehiculo tipoVehiculo = await _context.TipoVehiculos.FindAsync(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }
            return View(tipoVehiculo);
        }

        // POST: TipoVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoVehiculo);
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
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoVehiculo tipoVehiculo = await _context.TipoVehiculos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculos.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: TipoVehiculo/Delete/5



    }
}
