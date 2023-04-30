using System.Net;
using ApiGasolineras.Models;
using ApiGasolineras.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ApiGasolineras.Interfaces
{
    public interface IGasolinerasService
    {
        Task<HttpStatusCode> PostGasolineras();
        Task<HttpStatusCode> PostMunicipios();
        Task<IEnumerable<EstacionesServicio>> GetAll();
    }
}
