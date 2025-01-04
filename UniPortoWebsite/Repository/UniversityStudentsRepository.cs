using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    /// <summary>
    /// Class UniversityStudentsRepository.
    /// </summary>
    public class UniversityStudentsRepository
    {
        /// <summary>
        /// Checks the studet.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>UniversityStudent.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE CHECKING THE STUDENT
        /// or
        /// UNEXPECTED EXCEPTION WHILE CHECKING THE STUDENT
        /// </exception>
        public UniversityStudent CheckTheStudet(string username)
        {
            try
            {
                var model = new UniPorto();

                var res = model.UniversityStudents.Where(p => p.username == username).FirstOrDefault();
                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE CHECKING THE STUDENT", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE CHECKING THE STUDENT", ex);
            }
           
        }
    }
}