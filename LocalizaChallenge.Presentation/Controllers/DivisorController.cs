using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizaChallenge.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocalizaChallenge.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisorController : ControllerBase
    {
        private readonly IDivisorApplication _divisorApplication;
        public DivisorController(IDivisorApplication divisorApplication)
        {
            _divisorApplication = divisorApplication;
        }

        /// <summary>
        /// Pode ser acessado via URL, ex: port:0000/api/GetDivisores/numero_que_deseja_dividir
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        /// <response code="200"> Retornará todos os divisores daquele numero junto com os divisores Primos</response>
        [HttpGet("{numero}")]
        public string GetDivisores(double numero)
        {
            return _divisorApplication.Divisores(numero);

        }
    }
}
