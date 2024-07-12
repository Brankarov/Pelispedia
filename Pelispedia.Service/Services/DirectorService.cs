using Pelispedia.Domain.DbEntities;
using Pelispedia.Infrastructure.Repositories.Interfaces;
using Pelispedia.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelispedia.Service.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _DirectorRepository;
        public DirectorService(IDirectorRepository directorRepository)
        {
            _DirectorRepository = directorRepository;
        }

        public async Task<IEnumerable<Director>> GetAllDirectores()
        {
            var directores = await _DirectorRepository.GetAllDirector();
            return directores;
        }
    }
}
