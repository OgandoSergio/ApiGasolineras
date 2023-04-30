using Microsoft.AspNetCore.Mvc;
using ApiGasolineras.Servicios;
using System.Net;
using ApiGasolineras.Interfaces;
using NuGet.Protocol;

namespace ApiGasolineras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GasolinerasController : ControllerBase
    {

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGasolinerasService GasolinerasService;

        public GasolinerasController(IGasolinerasService gasolinerasService)
        {
           // _logger = logger;
            this.GasolinerasService = gasolinerasService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<HttpStatusCode> UpdateGasolineras()
        {
            return await GasolinerasService.PostGasolineras();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<HttpStatusCode> UpdateMunicipios()
        {
            return await GasolinerasService.PostMunicipios();
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var Estaciones = await GasolinerasService.GetAll();
                if (Estaciones.Any())
                {
                    return Ok(Estaciones);
                }
                return NotFound();
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}