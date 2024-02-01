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
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosService _oEmpleadoService;
        private readonly IMapper _oMapper;

        public EmpleadosController(DesarrolloContext oContext, IMapper oMapper)
        {
            _oEmpleadoService = new EmpleadosService(oContext);
            _oMapper = oMapper;
        }


        [EnableCors("PublicMethod")]
        [HttpGet]
        public ActionResult getEmpleados(int? idEmpleado)
        {
            try
            {
                if(idEmpleado == null)
                {
                    var response = _oEmpleadoService.GetEmpleados();
                    return Ok(response);
                }
                else
                {
                    //Cambiar una vez chequeado que funciona y generar el getbyID
                    var response = _oEmpleadoService.GetById(idEmpleado);
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
        public ActionResult CrearEmpleado([FromBody] EmpleadoViewModel request)
        {
            try
            {
                var response = _oEmpleadoService.Crear(_oMapper.Map<EmpleadoViewModel, Empleado>(request));
                return Created($"/Empleado/{request.CUIT}", response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("PublicMethod")]
        [HttpPut]
        public ActionResult ModificarEmp([FromBody] EmpleadoViewModelUpdate request)
        {
            try
            {
                var response = _oEmpleadoService.Modificar(_oMapper.Map<EmpleadoViewModelUpdate, Empleado>(request));
                
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
        public ActionResult BorrarEmp(int id)
        {
            try
            {
                var response = _oEmpleadoService.Eliminar(id);

                if (response == false)
                {
                    return NotFound();
                }

                return Ok(response);


            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
