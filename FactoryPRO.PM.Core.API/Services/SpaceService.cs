using AutoMapper;
using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SpaceService : ISpaceService
    {
        private ISpaceRepository _spaceRepository;
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaceRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="response"></param>
        public SpaceService(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public bool CreateSpace(SpaceDTO Space)
        {
            TblSpace space = _mapper.Map<TblSpace>(Space);
            return _spaceRepository.CreateSpace(space);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public bool DeleteSpace(SpaceDTO Space)
        {
            var result = false;
            TblSpace space = _mapper.Map<TblSpace>(Space);
            result = _spaceRepository.DeleteSpace(space);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SpaceID"></param>
        /// <returns></returns>
        public SpaceDTO GetSpaceByID(string SpaceID)
        { 
            TblSpace tblspace = new TblSpace();
            tblspace = _spaceRepository.GetSpaceByID(SpaceID);
            SpaceDTO spacedto = new SpaceDTO();
            spacedto = _mapper.Map<SpaceDTO>(tblspace);
            return spacedto;
        }

        public List<TOut> CastObject<TIn, TOut>(List<TIn> input)
        {
            List<TOut> lstOut = new List<TOut>();
            foreach (TIn tIn in input)
            {
                TOut tOut = _mapper.Map<TOut>(tIn);
                lstOut.Add(tOut);
            }
            return lstOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SpaceDTO> GetSpaces()
        {
            List<TblSpace> Spaces = new List<TblSpace>();
            Spaces = _spaceRepository.GetSpaces();
            
            //List<SpaceDTO> spaces = new List<SpaceDTO>();
            //foreach (TblSpace space in Spaces)
            //{
            //    SpaceDTO userDTO = _mapper.Map<SpaceDTO>(space);
            //    spaces.Add(userDTO);
            //}
         
            List<SpaceDTO> spaces= CastObject<TblSpace, SpaceDTO>(Spaces);
            return spaces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public bool UpdateSpace(SpaceDTO Space)
        {
            TblSpace space = _mapper.Map<TblSpace>(Space);
            return _spaceRepository.UpdateSpace(space);
        }
    }
}
