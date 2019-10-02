using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIFIPE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APILinx.Controllers
{
    public class APILinxController : Controller
    {
        [HttpGet]
        [Route("consulta-marca")]
        public async Task<List<MarcaVeiculoViewModel>> ConsultaMarvaVeiculo()
        {

            var client = new HttpClient();
            try
            {
                string url = "http://fipeapi.appspot.com/api/1/carros/marcas.json";
                var response = await client.GetStringAsync(url);
                var marcas = JsonConvert.DeserializeObject<List<MarcaVeiculoViewModel>>(response);
                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("consulta-veiculo/{id:int}")]
        public async Task<List<VeiculoViewModel>> ConsultaVeiculo(int id)
        {
            var client = new HttpClient();
            try
            {
                string url = $"http://fipeapi.appspot.com/api/1/carros/veiculos/{id}.json";
                var response = await client.GetStringAsync(url);
                var veiculo = JsonConvert.DeserializeObject<List<VeiculoViewModel>>(response);
                return veiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("consulta-veiculo-modelo/{id:int}/{idVeiculo:int}")]
        public async Task<List<VeiculoModeloViewModel>> ConsultaVeiculoModelo(int id, int idVeiculo)
        {
            var client = new HttpClient();

            try
            {
                string url = $"http://fipeapi.appspot.com/api/1/carros/veiculo/{id}/{idVeiculo}.json";
                var response = await client.GetStringAsync(url);
                var veiculo = JsonConvert.DeserializeObject<List<VeiculoModeloViewModel>>(response);
                return veiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("consulta-preco/{id:int}/{idVeiculo:int}/{key}")]
        public async Task<CarrosVeiculoViewModel> ConsultaPreco(int id, int idVeiculo, string key)
        {
            var client = new HttpClient();
            try
            {
                string url = $"http://fipeapi.appspot.com/api/1/carros/veiculo/{id}/{idVeiculo}/{key}.json";
                var response = await client.GetStringAsync(url);
                var preco = JsonConvert.DeserializeObject<CarrosVeiculoViewModel>(response);
                return preco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}