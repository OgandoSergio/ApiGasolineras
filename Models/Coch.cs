﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ApiGasolineras.Models
{
    public partial class Coch
    {
        public int IdCoche { get; set; }
        public string codref { get; set; }
        public string mimeType { get; set; }
        public string url { get; set; }
        public string guid { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public int IdTipoCombustible { get; set; }
        public double consumo { get; set; }
        public bool EsPlantilla { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_modificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual TiposCombustible IdTipoCombustibleNavigation { get; set; }
    }
}