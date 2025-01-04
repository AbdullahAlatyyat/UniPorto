using GraduationProject.UniPortoWebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniPortoWebAPI.EF;


namespace UniPortoWebAPI.Repository
{
    public class UniversityStudentsRepository
    {
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