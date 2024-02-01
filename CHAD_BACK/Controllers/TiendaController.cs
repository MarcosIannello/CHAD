using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DAL.Context.DesarrolloContext;
using Microsoft.AspNetCore.Cors;
using BLL;
using CHAD_BACK.Model.viewModels;


namespace CHAD_BACK.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]

    public class TiendaController : ControllerBase
    {
        private readonly TiendaService _oTiendaService;
        private readonly IMapper _oMapper;

        public TiendaController(DesarrolloContext oContext, IMapper oMapper)
        {
            _oTiendaService = new TiendaService(oContext);
            _oMapper = oMapper;
        }

        [EnableCors("PublicMethod")]
        [HttpGet]
        public ActionResult getTiendas(int? id)
        {
            try
            {
                if (id == null)
                {

                    var response = _oTiendaService.GetTiendas();
                    return Ok(response);

                }
                else
                {
                    var response = _oTiendaService.GetById(id);
                    return Ok(response);
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpPost]
        public ActionResult Crear([FromBody] TiendaViewModel request)
        {
            try
            {
                var response = _oTiendaService.Crear(_oMapper.Map<TiendaViewModel, TIENDA>(request));
                return Created($"/Tienda/{request.NRO_TIENDA}", response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [EnableCors("PublicMethod")]
        [HttpPut]
        public ActionResult Modificar([FromBody] TiendaViewModel request)
        {
            try
            {
                var response = _oTiendaService.Modificar(_oMapper.Map<TiendaViewModel, TIENDA>(request));

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpDelete]
        public ActionResult Eliminar(int id)
        {
            try
            {
                var response = _oTiendaService.Eliminar(id);

                if(response == false)
                {
                    return NotFound();
                }

                return Ok(response);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
