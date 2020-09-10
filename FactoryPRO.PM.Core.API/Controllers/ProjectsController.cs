using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryPRO.PM.Core.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;

namespace FactoryPRO.PM.Core.API.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private IProjectService _projectService;
      /// <summary>
      /// 
      /// </summary>
      /// <param name="projectService"></param>
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Projects/GetProjects")]
        public APIResponse GetProjects(string ModuleID)
        {
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _projectService.GetProjects(ModuleID)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Projects/GetProjectByID")]
        public ProjectDTO GetProjectByID(string ProjectID,string ModuleID)
        {
            return _projectService.GetProjectByID(ProjectID,ModuleID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Projects/GetProjectsByUserID")]
        public APIResponse GetProjectsByUserID(long UserID, string ModuleID)
        {
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _projectService.GetProjectsByUserID(UserID, ModuleID)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Projects/CreateProject")]
        public bool CreateProject(FullProjectDTO project)
        {
            project.projectDTO.CreatedDate = DateTime.UtcNow;
             return _projectService.CreateProject(project);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="project"></param>
       /// <returns></returns>
        [Route("api/Projects/UpdateProject")]
        public bool UpdateProject(FullProjectDTO project)
        {
            project.projectDTO.UpdatedDate = DateTime.UtcNow;
            return _projectService.UpdateProject(project);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="project"></param>
       /// <returns></returns>
        [Route("api/Projects/DeleteProject")]
        public bool DeleteProject(ProjectDTO project)
        {
            return _projectService.DeleteProject(project);
        }


    }
}
