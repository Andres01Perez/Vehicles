﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Vehicles.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }

        [Display(Name = "Document type")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombre { get; set; }
    }
}
