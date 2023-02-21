using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TallerMecanico.Common.Enums;

namespace TallerMecanico.API.Datos.Entidades
{
    public class Usuario : IdentityUser
    {
      
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }

        [Display(Name = "Tipo de documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public TipoDocumento TipoDocumento { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Documento { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Direccion { get; set; }



        [Display(Name = "Foto")]
        public Guid idImagen { get; set; }

        //TODO: Fix ubicación de imagen
        public string rutaImagen => idImagen == Guid.Empty
            ? $"https://localhost:44345/imagenes/images.png"
            : $"https://localhost:44345/imagenes/images.png";


        [Display(Name = "Tipo de usuario")]
        public TipoUsuario TipoUsuario { get; set; }


        public string NombreCompleto => $"{Nombre} {Apellido}";





    }
}
