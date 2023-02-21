using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Datos;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Ayudadores
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public UserHelper(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IdentityResult> AddUserAsync(Usuario usuario, string password)
        {
            return await _userManager.CreateAsync(usuario, password);
        }

        public async Task AddUserToRoleAsync(Usuario usuario, string nombreRol)
        {
            await _userManager.AddToRoleAsync(usuario, nombreRol);
        }

        public async  Task ChecRoleAsync(string nombreRol)
        {
            bool existeRol = await _roleManager.RoleExistsAsync(nombreRol);
            if (!existeRol)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = nombreRol });
            }
        }

        public async Task<Usuario> GetUsuarioAsync(string email)
        {
            return await _context.Users
                .Include(x=> x.TipoDocumento)
                .FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task<bool> IsUserInRoleAsync(Usuario usuario, string nombreRol)
        {
            return await _userManager.IsInRoleAsync(usuario, nombreRol);
        }
    }
}
