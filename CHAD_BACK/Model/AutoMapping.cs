using AutoMapper;
using CHAD_BACK.Model.viewModels;
using DAL.Context.DesarrolloContext;
using Microsoft.Extensions.Hosting;

namespace CHAD_BACK.Model
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Empleado, EmpleadoViewModel >();
            CreateMap<EmpleadoViewModel, Empleado>();

            //Mapeo especifico para la edicion de empleados
            CreateMap<EmpleadoViewModelUpdate, Empleado>();

            CreateMap<TIENDA, TiendaViewModel>();
            CreateMap<TiendaViewModel, TIENDA>();

            //CreateMap<Sistema, SistemaViewModel>();
            //CreateMap<SistemaViewModel, Sistema>();

            //CreateMap<publicacion, PublicacionViewModel>();
            //CreateMap<PublicacionViewModel, publicacion>();

            //CreateMap<proyecto, ProyectoViewModel>();
            //CreateMap<ProyectoViewModel, proyecto>();
        }
    }
}
