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
    /// Class ExperianceRepository.
    /// </summary>
    public class ExperianceRepository
    {
        /// <summary>
        /// The model
        /// </summary>
        UniPorto model = new UniPorto();
        /// <summary>
        /// Gets all experiance.
        /// </summary>
        /// <returns>List&lt;Experiance&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All Experiance
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All Experiance
        /// </exception>
        public List<Experiance> GetAllExperiance()
        {
            try
            {
                var res = model.Experiances.ToList();

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All Experiance ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All Experiance ", ex);
            }
        }
        /// <summary>
        /// Gets the experiance by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Experiance.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING Experiance BY ID
        /// or
        /// UNEXPECTED EXCEPTION WHILE GETTING Experiance BY ID
        /// </exception>
        public Experiance GetExperianceByID(int id)
        {

            try
            {

                var res = model.Experiances.Find(id);

                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING Experiance BY ID ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING Experiance BY ID", ex);
            }
        }
        /// <summary>
        /// Adds the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE GETTING ADDING  Experiance
        /// or
        /// UNEXPECTED EXCEPTION WHILE ADDING  Experiance
        /// </exception>
        public bool AddExperiance(Experiance experiance)
        {
            bool added = false;

            try
            {
                using(var model=new UniPorto())
                {
                    model.Experiances.Add(experiance);
                    model.SaveChanges();
                    added = true;
                }
                

                return added;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING ADDING  Experiance ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING  Experiance", ex);
            }
        }
        /// <summary>
        /// Deletes the experiance.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE DELETING Experiance
        /// or
        /// UNEXPECTED EXCEPTION WHILE DELETING Experiance
        /// </exception>
        public bool DeleteExperiance(int Id)
        {
            bool Deleted = false;

            try
            {

                var obj = model.Experiances.Find(Id);
                model.Experiances.Remove(obj);
                model.SaveChanges();
                Deleted = true;

                return Deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETING Experiance ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETING Experiance", ex);
            }
        }
        /// <summary>
        /// Edits the experiance.
        /// </summary>
        /// <param name="experiance">The experiance.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE UPDATING Language
        /// or
        /// UNEXPECTED EXCEPTION WHILE UPDATING Language
        /// </exception>
        public bool EditExperiance(Experiance experiance)
        {
            bool Updated = false;

            try
            {

                model.Experiances.AddOrUpdate(experiance);
                model.SaveChanges();
                Updated = true;

                return Updated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE UPDATING Language ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE UPDATING Language", ex);
            }
        }

    }
}