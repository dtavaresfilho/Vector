using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Vector.Application.Dtos;
using Vector.Application.Interfaces;

namespace Vector.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IApplicationServiceUsuario applicationServiceUsuario;
        private readonly IApplicationServiceAPITeste applicationServiceAPITeste;

        public UsuariosController(IApplicationServiceUsuario applicationServiceUsuario, IApplicationServiceAPITeste applicationServiceAPITeste)
        {
            this.applicationServiceUsuario = applicationServiceUsuario;
            this.applicationServiceAPITeste = applicationServiceAPITeste;
        }

        [HttpGet]
        [Route("GetEmails")]
        public ActionResult<IEnumerable<string>> GetEmails()
        {
            List<string> listaEmails = new List<string>();

            if (ExisteRegistroDataHoje())
            {
                // Busca registros no banco de dados
                listaEmails = applicationServiceUsuario.GetAll().Select(x => x.Mail).ToList();
            }
            else
            {
                // Busca registros na API Teste 
                var listaUsuarios = applicationServiceAPITeste.GetUsuarios().ToList();

                // Adiciona registros no banco de dados
                foreach (var usuario in listaUsuarios)
                {
                    usuario.DataRegistro = DateTime.Now;
                    applicationServiceUsuario.Add(usuario);
                }

                listaEmails = listaUsuarios.Select(x => x.Mail).ToList();
            };

            return Ok(listaEmails);
        }

        [HttpGet]
        [Route("GetEmailsGroupedByCreatedDate")]
        public ActionResult<IEnumerable<string>> GetEmailsGroupedByCreatedDate()
        {
            List<UsuarioDto> listaUsuarios = new List<UsuarioDto>();

            if (ExisteRegistroDataHoje())
            {
                // Busca registros no banco de dados
                listaUsuarios = applicationServiceUsuario.GetAll().ToList();
            }
            else
            {
                // Busca registros na API Teste 
                listaUsuarios = applicationServiceAPITeste.GetUsuarios().ToList();

                // Adiciona registros no banco de dados
                foreach (var usuario in listaUsuarios)
                {
                    usuario.DataRegistro = DateTime.Now;
                    applicationServiceUsuario.Add(usuario);
                }
            };

            var listaUsuariosAgrupados = listaUsuarios.GroupBy(x => x.CreatedAt)
                                                       .Select(x => new
                                                       {
                                                           Data = x.Key,
                                                           Nomes = listaUsuarios.Where(u => u.CreatedAt == x.Key).Select(u => u.Name).ToList()
                                                       }).ToList();

            return Ok(listaUsuariosAgrupados);
        }

        private bool ExisteRegistroDataHoje()
        {
            var dataHojeInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var dataHojeFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59 ,59);

            return applicationServiceUsuario.GetAll()
                                            .Where(x => x.DataRegistro >= dataHojeInicio && 
                                                        x.DataRegistro <= dataHojeFim)
                                            .Any();
        }
    }
}
