using System.Data.Common;
using ApiGasolineras.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;
using Microsoft.EntityFrameworkCore;
using ApiGasolineras.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGasolineras.Servicios
{
    public class GasolinerasService : IGasolinerasService
    {
        private readonly _dbContext _dbContext;
        public GasolinerasService(_dbContext _DbContext) { 
            this._dbContext = _DbContext;
        }
        public async Task<IEnumerable<EstacionesServicio>> GetAll() { //Cambiar por DTO
            return await _dbContext.EstacionesServicios.ToListAsync();
        }
        public async Task<HttpStatusCode> PostGasolineras() {
            var client = new RestClient();
            var request = new RestRequest("https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/EstacionesTerrestres#response-json/", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK) {
                GetGasolinerasModel info = JsonConvert.DeserializeObject<GetGasolinerasModel>(response.Content, new JsonSerializerSettings
                {
                    Culture = new System.Globalization.CultureInfo("es-ES")  //Replace tr-TR by your own culture
                });
                _dbContext.UpdateRange(info.ListaEESSPrecio);
                await _dbContext.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
 
            return HttpStatusCode.InternalServerError;
        }

        public async Task<HttpStatusCode> PostMunicipios()
        {
            var client = new RestClient();
            var request = new RestRequest("https://sedeaplicaciones.minetur.gob.es/ServiciosRESTCarburantes/PreciosCarburantes/Listados/Municipios/", Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ComunidadesAutonomasProvinciasMunicipio> info = JsonConvert.DeserializeObject<List<ComunidadesAutonomasProvinciasMunicipio>>(response.Content);
                await _dbContext.AddRangeAsync(info);
                await _dbContext.SaveChangesAsync();

                return HttpStatusCode.OK;
            }

            return HttpStatusCode.InternalServerError;
        }

        private class GetGasolinerasModel {
            public string Fecha { get; set; }
            public List<EstacionesServicio> ListaEESSPrecio { get; set; } 
            public string Nota { get; set; }
            public string ResultadoConsulta { get; set; }
        }

    }
}
