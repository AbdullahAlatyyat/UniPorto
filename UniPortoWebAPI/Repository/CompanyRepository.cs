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
    public class CompanyRepository
    {
        UniPorto model = new UniPorto();
        public int AddCommpanyAd(CompanyAd newCompany)
        {
            try
            {
               
                model.CompanyAds.Add(newCompany);
                model.SaveChanges();
                return newCompany.Id;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Add CompanyAds ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Add CompanyAds ", ex);
            }


        }
        public bool DeleteCompanyAd (int id )
        {

            bool isDeleted = false;

            try
            {
               
                var res = model.CompanyAds.Find(id);
                model.CompanyAds.Remove(res);
                model.SaveChanges();
                isDeleted = true;
                return isDeleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Delete  CompanyAds ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Delete  CompanyAds ", ex);
            }
        }
        public List<CompanyAd> GetAllCompanyAds()
        {
            try
            {
               
                var res = model.CompanyAds.ToList();
                return res;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting All CompanyAds ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting All CompanyAds ", ex);
            }
        }
        public CompanyAd GetCompanyAdById(int id)
        {
            try
            {
                
                var res = model.CompanyAds.Find(id);
                return res;


            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Geting By ID  CompanyAds ", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Geting By ID CompanyAds ", ex);
            }
        }
        public bool UpdateCompanyAd(CompanyAd toUpdauteCompanyAd)
        {
            var isUpdated = false;
            try
            {

                model.CompanyAds.AddOrUpdate(toUpdauteCompanyAd);
                model.SaveChanges();
                isUpdated = true;
                return isUpdated;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE Updating CompanyAd", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE Updating CompanyAd", ex);
            }

        }
        
    }

    
}