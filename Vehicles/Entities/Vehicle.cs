﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vehicles.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int VehicleTypeId { get; set; }

        public int BrandId { get; set; }

        [JsonIgnore]
        [Display(Name = "Tipo de vehículo")]
        public VehicleType VehicleType { get; set; }

        [JsonIgnore]
        [Display(Name = "Marca")]
        public Brand Brand { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }

        [JsonIgnore]
        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
        public int Model { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Placa { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }
    }
}
