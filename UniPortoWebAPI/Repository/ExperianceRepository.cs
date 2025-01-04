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
    public class ExperianceRepository
    {
        UniPorto model = new UniPorto();
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