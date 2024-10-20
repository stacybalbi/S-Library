using System;
using AutoMapper;
using SLibrary.BusinessLayers.Dtos.SLibrary;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Mappers.SLibrary
{
	public class SLibraryMapper : Profile
	{
		public SLibraryMapper()
		{
			CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Libro, LibroDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
	}
}

