using DAL.Context.DesarrolloContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmpleadosService
    {
        private readonly DesarrolloContext _oContext;

        public EmpleadosService(DesarrolloContext oContext)
        {
            _oContext = oContext;
        }

        public List<Empleado> GetEmpleados()
        {
            try
            {
                var response = _oContext.Empleados.ToList();
                return response;
            }
            catch (Exception)
            {
                return new List<Empleado>();
                throw new Exception("Error al obtener los empleados");
            }
        }

        public Empleado GetById(int? id)
        {
            try
            {
                var response = _oContext.Empleados.FirstOrDefault(x => x.id_Empleado == id);
                return response;

            }catch(Exception ex)
            {
                   throw new($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public Empleado Crear(Empleado emp)
        {
            try
            {
                _oContext.Empleados.Add(emp);
                _oContext.SaveChanges();
                return emp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public Empleado Modificar(Empleado emp)
        {
            try
            {
                var empDB = _oContext.Empleados.FirstOrDefault(empDB => empDB.id_Empleado == emp.id_Empleado);

                if(empDB != null)
                {
                    empDB.MAIL = emp.MAIL;
                    empDB.TURNO = emp.TURNO;
                    empDB.EMPRESA = emp.EMPRESA;
                    empDB.TIENDA = emp.TIENDA;
                    empDB.PUESTO = emp.PUESTO;
                    empDB.FECHA_ALTA = emp.FECHA_ALTA;
                    empDB.COD_OPERARIO = emp.COD_OPERARIO;
                    empDB.CALLE = emp.CALLE;
                    empDB.ALTURA_CALLE = emp.ALTURA_CALLE;
                    empDB.LOCALIDAD = emp.LOCALIDAD;
                    empDB.COD_POSTAL = emp.COD_POSTAL;
                    empDB.COMPANIA_CEL = emp.COMPANIA_CEL;
                    empDB.TELEFONO = emp.TELEFONO;
                    empDB.NRO_CUENTA = emp.NRO_CUENTA;
                    empDB.BANCO = emp.BANCO;
                    empDB.VTO_FECHA_SANITARIA = emp.VTO_FECHA_SANITARIA;
                    empDB.UNIFORME = emp.UNIFORME;
                    empDB.TALLE_CHOMBA = emp.TALLE_CHOMBA;
                    empDB.TALLE_PANTALON = emp.TALLE_PANTALON;
                    empDB.FECHA_BAJA = emp.FECHA_BAJA;
                    _oContext.SaveChanges();

                    return emp;
                }
                else
                {
                    throw new Exception("Empleado no encontrado");
                }
               
            }catch(Exception ex)
            {
                throw new($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var empDb = _oContext.Empleados.FirstOrDefault(empdb => empdb.id_Empleado == id);

                if (empDb != null)
                {
                    _oContext.Remove(empDb);
                    _oContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                throw new($"Ocurrio el siguiente error {ex.Message}");
            }
        }
    }
}
