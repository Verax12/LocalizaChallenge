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

        // GET: api/<ValuesController>
        [HttpGet("{num}")]
        public string GetDivisores(double num)
        {
            return _divisorApplication.Divisores(num);

        }
    }
}
