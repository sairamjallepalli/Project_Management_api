using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
  public interface ISpaceService 
    {
        List<SpaceDTO> GetSpaces();

        SpaceDTO GetSpaceByID(string SpaceID);

        bool CreateSpace(SpaceDTO Space);

        bool UpdateSpace(SpaceDTO Space);

        bool DeleteSpace(SpaceDTO Space);

    }
}
