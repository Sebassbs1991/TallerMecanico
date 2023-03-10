using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Ayudadores;
using TallerMecanico.API.Datos.Entidades;
using TallerMecanico.Common.Enums;

namespace TallerMecanico.API.Datos
{
    public class CargarInfo
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public CargarInfo(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task CargarDatosAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoVehiculosAsync();
            await CheckProcedimientosAsync();
            await CheckTipoDocumentosAsync();
            await CheckRolesAsync();
            await CheckUsuarioAsync("1010", "Sebastian", "Buri", "sebastianburi@hotmail.com", "022988700", "Carcelén", TipoUsuario.Administrador);
            await CheckUsuarioAsync("2020", "Cristina", "Villacis", "cvillacis@hotmail.com", "0229404040", "Ofelia", TipoUsuario.Secretaria);
            await CheckUsuarioAsync("3030", "Raul", "Buri", "sebastian.1991.buri@gmail.com", "022988700", "Carcelén", TipoUsuario.Tecnico);

        }

        private async Task CheckUsuarioAsync(string documento, string nombre, string apellido, string email, string telefono, string direccion, TipoUsuario tipoUsuario)
        {
            Usuario usuario = await _userHelper.GetUsuarioAsync(email);
            if(usuario == null)
            {
                usuario = new Usuario
                {
                    Direccion = direccion,
                    Documento = documento,
                    TipoDocumento = _context.TipoDocumentos.FirstOrDefault(x => x.Descripcion == "Cédula"),
                    Email = email,
                    Nombre = nombre,
                    Apellido = apellido,
                    PhoneNumber = telefono,
                    UserName = email,
                    TipoUsuario = tipoUsuario
                };

                await _userHelper.AddUserAsync(usuario, "123456");
                await _userHelper.AddUserToRoleAsync(usuario, tipoUsuario.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.ChecRoleAsync(TipoUsuario.Administrador.ToString());
            await _userHelper.ChecRoleAsync(TipoUsuario.Secretaria.ToString());
            await _userHelper.ChecRoleAsync(TipoUsuario.Tecnico.ToString());
            await _userHelper.ChecRoleAsync(TipoUsuario.Usuario.ToString());
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
