using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
using UniPortoWebAPI.Repository;

namespace UniPortoWebAPI.Manager
{
    public class ProjectManager
    {
        static ProjectRepository respository = new ProjectRepository();
        public static int AddNewProject(Project newProject)
        {
            return respository.AddNewProject(newProject);
        }
        public static bool UpdateProject(Project updatedProject)
        {
            return respository.UpdateProject(updatedProject);
        }

        public static bool DeleteProject(int projectId)
        {
            return respository.DeleteProject(projectId);
        }

        public static List<Project> GetAllProjectsByProfileId(int profileId)
        {
            return respository.GetAllProjectsByProfileId(profileId);
        }

    }
}