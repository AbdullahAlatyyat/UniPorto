using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class ProjectRepository.
    /// </summary>
    public class ProjectRepository
    {
        /// <summary>
        /// Adds the new project.
        /// </summary>
        /// <param name="newProject">The new project.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ADDING PROJECT
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING PROJECT
        /// </exception>
        public int AddNewProject(Project newProject)
        {
            try
            {
                using (var context = new UniPorto())
                {
                    var model = new UniPorto();
                    model.Projects.Add(newProject);
                    model.SaveChanges();
                }
                return newProject.Id;

            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ADDING PROJECT ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING PROJECT", ex);
            }
        }
        /// <summary>
        /// Deletes the project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE DELETING THE PROJECT
        /// or
        /// UNEXPECTED EXCEPTION WHILE DELETING THE PROJECT
        /// </exception>
        public bool DeleteProject(int projectId)
        {
            try
            { bool deleted = false;
                using (var context = new UniPorto())
                {
                   
                    var model = new UniPorto();
                    var temp = model.Projects.Find(projectId);
                    model.Projects.Remove(temp);
                    model.SaveChanges();
                    deleted = true;
                   
                }
                return deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETING THE PROJECT ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETING THE PROJECT", ex);
            }

        }

        /// <summary>
        /// Gets all projects by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns>List&lt;Project&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ALL PROJECTS
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING ALL PROJECTS
        /// </exception>
        public List<Project> GetAllProjectsByProfileId(int profileId)
        {
            try
            {
                var res = new List<Project>();
                using (var context = new UniPorto())
                {
                    var model = new UniPorto();
                   res =  model.Projects.Where(p=>p.profileId== profileId).ToList();
                }
                return res;

            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ALL PROJECTS ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING ALL PROJECTS", ex);
            }
        }
        /// <summary>
        /// Updates the project.
        /// </summary>
        /// <param name="updatedProject">The updated project.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE UPDATING THE PROJECT
        /// or
        /// UNEXPECTED EXCEPTION WHILE UPDATING THE PROJECT
        /// </exception>
        public bool UpdateProject(Project updatedProject)
        {
            try
            {
                bool updated = false;

                using (var context = new UniPorto())
                {
                    var model = new UniPorto();
                    model.Projects.AddOrUpdate(updatedProject);
                    model.SaveChanges();
                    updated = true;
                  
                }
                return updated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE UPDATING THE PROJECT ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE UPDATING THE PROJECT", ex);
            }

        }

    }
}