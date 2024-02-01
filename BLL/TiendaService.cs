using DAL.Context.DesarrolloContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TiendaService
    {
        private readonly DesarrolloContext _oContext;

        public TiendaService(DesarrolloContext oContext)
        {
            _oContext = oContext;
        }

        public List<TIENDA> GetTiendas()
        {
            try
            {
                var response = _oContext.TIENDAs.ToList();
                return response;
            }
            catch (Exception)
            {
                return new List<TIENDA>();
                throw new Exception("Error al obtener las tiendas");
            }
        }

        public TIENDA GetById(int? id)
        {
            try
            {
                var response = _oContext.TIENDAs.FirstOrDefault(x => x.ID_TIENDA == id);
                return response;

            }catch(Exception ex)
            {
                   throw new($"Ocurrio el siguiente error {ex.Message}");
            } 
        }

        public TIENDA Crear(TIENDA tienda)
        {
            try
            {
                _oContext.TIENDAs.Add(tienda);
                _oContext.SaveChanges();
                return tienda;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public TIENDA Modificar(TIENDA tienda)
        {
            try
            {
                _oContext.TIENDAs.Update(tienda);
                _oContext.SaveChanges();
                return tienda;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var tiendaDB = _oContext.TIENDAs.FirstOrDefault(x => x.ID_TIENDA == id);

                if (tiendaDB == null)
                {
                    return false;
                }

                _oContext.TIENDAs.Remove(tiendaDB);
                _oContext.SaveChanges();
                return true;


            }catch(Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }   
        }
    }
}
