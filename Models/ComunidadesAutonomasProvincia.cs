﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ApiGasolineras.Models
{
    public partial class ComunidadesAutonomasProvincia
    {
        public ComunidadesAutonomasProvincia()
        {
            EstacionesServicios = new HashSet<EstacionesServicio>();
        }

        public int IDPovincia { get; set; }
        public int IDCCAA { get; set; }
        public string Provincia { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual ComunidadesAutonoma IDCCAANavigation { get; set; }
        public virtual ICollection<EstacionesServicio> EstacionesServicios { get; set; }
    }
}