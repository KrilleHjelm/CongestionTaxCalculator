using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongestionTaxCalculatorController : ControllerBase
    {
        readonly ICongestionTaxCalculatorService _congestionTaxCalculatorService;
        public CongestionTaxCalculatorController(ICongestionTaxCalculatorService congestionTaxCalculatorService)
        {
            _congestionTaxCalculatorService = congestionTaxCalculatorService;
        }

        [HttpGet("{city}/calculatecongestiontax/{date}/{vehicle}/{serialNumber}")]
        public int CalculateCongestionTax(string city, DateTime date, string vehicle, string serialNumber)
        {
            return _congestionTaxCalculatorService.CalculateCongestionTax(date, vehicle, city, serialNumber);
        }
    }
}
