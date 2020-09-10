using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;

namespace FactoryPRO.PM.Core.API.Controllers
{
   
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
   // [ApiExplorerSettings(IgnoreApi = true)]
  
    public class SpaceController : ControllerBase
    {
        private ISpaceService _spaceService;
        private ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaceService"></param>
        /// <param name="logger"></param>
        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }


      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
       [Route("api/Spaces/GetSpaces")]
        public APIResponse GetSpaces()
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.GetSpaces()
                };
            }
            catch(Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1
                };
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="SpaceID"></param>
       /// <returns></returns>
        [Route("api/Spaces/GetSpaceByID")]
        public APIResponse GetSpaceByID(string SpaceID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.GetSpaceByID(SpaceID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Spaces/CreateSpace")]
        public bool CreateSpace(SpaceDTO space)
        {
            try
            {
                return _spaceService.CreateSpace(space);
            }
            catch (Exception ex)
            {
                //log
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        [Route("api/Spaces/UpdateSpace")]
        public bool UpdateSpace(SpaceDTO space)
        {
            try
            {
                return _spaceService.UpdateSpace(space);
            }
            catch (Exception ex)
            {
                //log
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        [Route("api/Spaces/DeleteSpace")]
        public bool DeleteSpace(SpaceDTO space)
        {
            try
            {
                return _spaceService.DeleteSpace(space);
            }
            catch (Exception ex)
            {
                //log
            }
            return false;
        }

    }
}
