using exemplo_macoratti.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace exemplo_macoratti.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private IRepository repository;

        public ReservasController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Reserva> GEt() => repository.Reservas;

        [HttpGet("{id}")]
        public Reserva Get(int id) => repository[id];

        [HttpPost]
        public Reserva Post([FromBody] Reserva res) => repository.AddReserva(new Reserva{
            Nome = res.Nome,
            InicioLocacao = res.InicioLocacao,
            FimLocacao = res.FimLocacao
        });
        [HttpPut]
        public Reserva Put([FromForm] Reserva res) => repository.UpdateReserva(res);

        [HttpPatch]
        public StatusCodeResult Patch(int id,  [FromForm] JsonPatchDocument<Reserva> patch)
        {
            Reserva res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public void Delete(int id) => repository.DeleteReserva(id);
    }
}
