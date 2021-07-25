using Microsoft.AspNetCore.Mvc;
using MutualFund.Loggers;
using MutualFund.Models;
using MutualFund.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MutualFundNav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualFundNavController : ControllerBase
    {
        private readonly IMutualFundRepository _mutualFundRepository;
        private readonly ILoggerManager _logger;

        public MutualFundNavController(IMutualFundRepository mutualFundRepository,ILoggerManager logger)
        {
            _mutualFundRepository = mutualFundRepository;
            _logger = logger;
        }

        // GET: api/<MutualFundNavController>
        [HttpGet("{mutualFundName:alpha}")]
        public IActionResult GetMutualFundDetail(string mutualFundName)
        {
            if (string.IsNullOrEmpty(mutualFundName))
            {
                return BadRequest();
            }
            MutualFundDetails mutualFund = _mutualFundRepository.GetMutualFund(mutualFundName);
            if(mutualFund == null)
            {
                return NoContent();
            }
            _logger.LogInformation($"MutualFundDetails with mutualFund name{mutualFundName} returned");
            return Ok(mutualFund);
        }
    }   
}

