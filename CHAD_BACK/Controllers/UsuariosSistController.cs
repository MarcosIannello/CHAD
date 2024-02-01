using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DAL.Context.DesarrolloContext;
using Microsoft.AspNetCore.Cors;
using BLL;
using CHAD_BACK.Model.viewModels;
using Azure.Core;

namespace CHAD_BACK.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
    public class UsuariosSistController : ControllerBase
    {
        private readonly UsuariosService _oUsuariosService;
        private readonly IMapper _oMapper;

        public UsuariosSistController(DesarrolloContext oContext, IMapper oMapper)
        {
            _oUsuariosService = new UsuariosService(oContext);
            _oMapper = oMapper;
        }

        [EnableCors("PublicMethod")]
        [HttpGet]
        public ActionResult GetUsuarios(int? idUsuario)
        {
            try
            {
                if (idUsuario == null)
                {
                    var response = _oUsuariosService.GetUsuarios();
                    if (response == null)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
                else
                {
                    var response = _oUsuariosService.GetById(idUsuario);
                    if (response == null)
                    {
                        return NotFound();
                    }
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpPost]
        public ActionResult CrearUser([FromBody] USUARIOS_SIST request)
        {
            try 
            {
                var response = _oUsuariosService.Crear(request);
                return Created($"/user/{request.ID_USUARIO}", response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpPut]
        public ActionResult ModificarUser([FromBody] USUARIOS_SIST request)
        {
            try 
            {
                var response = _oUsuariosService.Modificar(request);
                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpDelete]
        public ActionResult EliminarUser(int id)
        {
            try
            {
                var response = _oUsuariosService.Eliminar(id);

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
