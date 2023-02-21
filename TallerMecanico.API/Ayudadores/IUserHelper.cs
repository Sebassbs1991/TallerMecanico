using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.API.Datos.Entidades;

namespace TallerMecanico.API.Ayudadores
{
    public interface IUserHelper
    {
        Task<Usuario> GetUsuarioAsync(string email);
        Task<IdentityResult> AddUserAsync(Usuario usuario, string password);
        Task ChecRoleAsync(string nombreRol);
        Task AddUserToRoleAsync(Usuario usuario, string nombreRol);
        Task<bool> IsUserInRoleAsync(Usuario usuario, string nombreRol);


    }
}
