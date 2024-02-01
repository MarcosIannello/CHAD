using DAL.Context.DesarrolloContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuariosService
    {
        private readonly DesarrolloContext _oContext;

        public UsuariosService(DesarrolloContext oContext)
        {
            _oContext = oContext;
        }

        public List<USUARIOS_SIST> GetUsuarios()
        {
            try
            {
                var response = _oContext.USUARIOS_SISTs.ToList();
                return response;
            }
            catch (Exception)
            {
                return new List<USUARIOS_SIST>();
                throw new Exception("Error al obtener los usuarios");
            }
        }

        public USUARIOS_SIST GetById(int? id)
        {
            try
            {
                var response = _oContext.USUARIOS_SISTs.FirstOrDefault(x => x.ID_USUARIO == id);
                return response;

            }
            catch (Exception ex)
            {
                throw new($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public USUARIOS_SIST Crear(USUARIOS_SIST user)
        {
            try
            {
                var HashedPassword = HashPassword(user.password);

                user.password = HashedPassword;


                _oContext.USUARIOS_SISTs.Add(user);
                _oContext.SaveChanges();
                return  user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public USUARIOS_SIST Modificar(USUARIOS_SIST user)
        {
            try
            {

                var HashedPassword = HashPassword(user.password);
                user.password = HashedPassword;

                _oContext.USUARIOS_SISTs.Update(user);
                _oContext.SaveChanges();
                return user;
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
                var user = _oContext.USUARIOS_SISTs.FirstOrDefault(x => x.ID_USUARIO == id);

                if (user == null)
                {
                    return false;
                }

                _oContext.USUARIOS_SISTs.Remove(user);
                _oContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrio el siguiente error {ex.Message}");
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
