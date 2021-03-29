using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using AzureSamples.AzureSQL.Services;

namespace AzureSamples.AzureSQL.Controllers
{
    [ApiController]
    [Route("shopping_cart")]
    public class ShoppingCartController : ControllerQuery
    {
        public ShoppingCartController(IConfiguration config, ILogger<ShoppingCartController> logger, IScaleOut scaleOut):
            base(config, logger, scaleOut, "shopping_cart") {}

        [HttpGet("{id}")]
        public async Task<JsonDocument> Get(int id)
        {
            return await this.Query(Verb.Get, id);
        }

        [HttpGet("package/{id}")]
        public async Task<JsonDocument> GetByPackage(int id)
        {
            return await this.Query(Verb.Get, id, extension: "by_package");
        }

        [HttpPut]
        public async Task<JsonDocument> Put([FromBody]JsonElement payload)
        {
            return await this.Query(Verb.Put, payload: payload);
        }
    }
}
