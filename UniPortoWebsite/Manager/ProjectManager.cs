using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class ProjectManager.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// The respository
        /// </summary>
        static ProjectRepository respository = new ProjectRepository();
        /// <summary>
        /// Adds the new project.
        /// </summary>
        /// <param name="newProject">The new project.</param>
        /// <returns>System.Int32.</returns>
        public static int AddNewProject(Project newProject)
        {
            return respository.AddNewProject(newProject);
        }
        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="updatedProject">The updated project.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool UpdateProject(Project updatedProject)
        {
            return respository.UpdateProject(updatedProject);
        }

        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteProject(int projectId)
        {
            return respository.DeleteProject(projectId);
        }

        /// <summary>
        /// Gets all projects by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;Project&gt;.</returns>
        public static List<Project> GetAllProjectsByProfileId(int profileId)
        {
            return respository.GetAllProjectsByProfileId(profileId);
        }

    }
}