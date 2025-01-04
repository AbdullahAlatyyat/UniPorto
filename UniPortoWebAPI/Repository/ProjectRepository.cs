using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;
namespace UniPortoWebAPI.Repository
{
    public class ProjectRepository
    {
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