using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Datos
{
    public class CargarInfo
    {
        private readonly DataContext _context;
        public CargarInfo(DataContext context)
        {
            _context = context;
        }

        public async Task   CargarDatosAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoVehiculosAsync();
            await CheckProcedimientosAsync();
            await CheckTipoDocumentosAsync();

        }

        private async Task CheckTipoDocumentosAsync()
        {
            _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "Cédula" });
            _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "Pasaporte" });
            _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "DNI" });
            _context.TipoDocumentos.Add(new TipoDocumento { Descripcion = "Tarjeta de Identidad" });
            await _context.SaveChangesAsync();


        }

        private async Task CheckProcedimientosAsync()
        {
            _context.Procedimientos.Add(new Procedimiento { Precio= 75, Descripcion = "Alineación" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 50, Descripcion = "Balanceo" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 45, Descripcion = "Lubricación de suspención delantera" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 45, Descripcion = "Lubricación de suspención trasera" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 150, Descripcion = "Frenos delanteros" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 95, Descripcion = "Frenos traseros" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 63, Descripcion = "Calibración de válvulas" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 29, Descripcion = "Aceite motor" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 125, Descripcion = "Filtro de aire" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 300, Descripcion = "Sistema eléctrico" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 30, Descripcion = "Cambio de llanta" });
            _context.Procedimientos.Add(new Procedimiento { Precio = 900, Descripcion = "Reparación de motor" });
            await _context.SaveChangesAsync();

        }

        private async Task CheckTipoVehiculosAsync()
        {
            if (!_context.TipoVehiculos.Any())
            {
                _context.TipoVehiculos.Add(new TipoVehiculo { Descripcion = "Carro" });
                _context.TipoVehiculos.Add(new TipoVehiculo { Descripcion = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
