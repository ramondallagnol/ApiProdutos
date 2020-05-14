using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProduto.Models;
using ApiProduto.Repositories;
using ApiProduto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}