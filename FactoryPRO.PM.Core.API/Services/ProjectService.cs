using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
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
    public class ProjectService : IProjectService 
    {
        private IProjectRepository _projectRepository;
        private IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="response"></param>
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullProject"></param>
        /// <returns></returns>
        public bool CreateProject(FullProjectDTO fullProject)
        {
            var result = false;
            TblProjects projects = _mapper.Map<TblProjects>(fullProject.projectDTO);
            TblCustomFields customFileds = _mapper.Map<TblCustomFields>(fullProject.customFieldsDTO);
            result = _projectRepository.CreateProject(projects,customFileds);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public bool DeleteProject(ProjectDTO Project)
        {
            var result = false;
            TblProjects projects = _mapper.Map<TblProjects>(Project);
            result = _projectRepository.DeleteProject(projects);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public ProjectDTO GetProjectByID(string ProjectID, string ModuleID)
        {
            TblProjects projects = _projectRepository.GetProjectByID(ProjectID,ModuleID);
            ProjectDTO space = _mapper.Map<ProjectDTO>(projects);
            return space;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public List<ProjectDTO> GetProjectsByUserID(long UserID, string ModuleID)
        {
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjectsByUserID(UserID, ModuleID);
            List<ProjectDTO> projects = new List<ProjectDTO>();
            foreach (TblProjects project in Projects)
            {
                ProjectDTO projobj = _mapper.Map<ProjectDTO>(project);
                projects.Add(projobj);
            }
            return projects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public List<ProjectDTO> GetProjects(string ModuleID)
        {
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjects(ModuleID);
            List<ProjectDTO> projects = new List<ProjectDTO>();
            foreach (TblProjects project in Projects)
            {
                ProjectDTO projobj = _mapper.Map<ProjectDTO>(project);
                projects.Add(projobj);
            }
            return projects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public bool UpdateProject(FullProjectDTO fullProject)
        {
            var result = false;
            TblProjects projects = _mapper.Map<TblProjects>(fullProject.projectDTO);
            TblCustomFields customFields = _mapper.Map<TblCustomFields>(fullProject.customFieldsDTO);
            result = _projectRepository.UpdateProject(projects,customFields);
            return result;
        }

    }
}
