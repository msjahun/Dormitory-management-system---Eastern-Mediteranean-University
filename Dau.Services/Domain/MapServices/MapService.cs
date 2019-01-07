using Dau.Core.Domain.EmuMap;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Domain.MapServices
{
    public class MapService : IMapService
    {
        private readonly IRepository<MapSection> _mapSectionRepo;

        public MapService(IRepository<MapSection> mapSectionRepo)
        {

            _mapSectionRepo = mapSectionRepo;
        }


        public string GetMapSectionById(long id)
        {
            var mapSection = _mapSectionRepo.GetById(id);
            if (mapSection == null) return null;

            return "https://www.emu.edu.tr/campusmap?design=empty#" +"b" + mapSection.BuildingId;

        }
    }
}
