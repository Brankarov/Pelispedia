﻿using Pelispedia.Service.DTOs;

namespace Pelispedia.Service.Services.Interface
{
    public interface IPeliculaService
    {
        Task<PeliculaDTO> GetPeliculaById(int id);
        Task<IEnumerable<PeliculaDTO>> GetAllPeliculas();
        Task<IEnumerable<PeliculaDetailedDTO>> GetDetailedMovies();
    }
}