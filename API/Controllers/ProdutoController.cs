using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Workflows;

namespace UStart.API.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produto")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository ProdutoRepository;
        private readonly ProdutoWorkflow ProdutoWorkflow;

        public ProdutoController(IProdutoRepository produtoRepository, ProdutoWorkflow produtoWorkflow)
        {
            this.ProdutoRepository = produtoRepository;
            this.ProdutoWorkflow = produtoWorkflow;
        }

        /// <summary>
        /// Consultar todos os s
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get([FromQuery] string pesquisa)
        {
            return Ok(ProdutoRepository.Pesquisar(pesquisa));
        }

                /// <summary>
        /// Consultar apenas um 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetPorId([FromRoute] Guid id)
        {
            return Ok(ProdutoRepository.ConsultarPorId(id));
        }


        /// <summary>
        /// Método para inserir no banco um regitro de  produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody] ProdutoCommand command )
        {
            ProdutoWorkflow.Add(command);
            if (ProdutoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(ProdutoWorkflow.GetErrors());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] ProdutoCommand command )
        {
            ProdutoWorkflow.Update(id, command);
            if (ProdutoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(ProdutoWorkflow.GetErrors());
        }

        [HttpDelete("{id}")]        
        public IActionResult Excluir([FromRoute] Guid id)
        {
            ProdutoWorkflow.Delete(id);
            if (ProdutoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(ProdutoWorkflow.GetErrors());
        }
    }
}
