using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public  interface IProjectRepository
    {
        List<TblProjects> GetProjects(string ModuleID);

        List<TblProjects> GetProjectsByUserID(long UserID, string ModuleID);

        TblProjects GetProjectByID(string ProjectID,string ModuleID);

        bool CreateProject(TblProjects Project,TblCustomFields customFields);

        bool UpdateProject(TblProjects Project, TblCustomFields customFields);

        bool DeleteProject(TblProjects Project);
    }
}
