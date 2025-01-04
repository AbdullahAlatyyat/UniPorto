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
    /// Class CompanyRepository.
    /// </summary>
    public class CompanyRepository
    {
        /// <summary>
        /// The model
        /// </summary>
        UniPorto model = new UniPorto();
        /// <summary>
        /// Adds the commpany ad.
        /// </summary>
        /// <param name="newCompany">The new company.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Add CompanyAds
        /// or
        /// UNEXPECTED EXCEPTION WHILE Add CompanyAds
        /// </exception>
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
        /// <summary>
        /// Deletes the company ad.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Delete  CompanyAds
        /// or
        /// UNEXPECTED EXCEPTION WHILE Delete  CompanyAds
        /// </exception>
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
        /// <summary>
        /// Gets all company ads.
        /// </summary>
        /// <returns>List&lt;CompanyAd&gt;.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting All CompanyAds
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting All CompanyAds
        /// </exception>
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
        /// <summary>
        /// Gets the company ad by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CompanyAd.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Geting By ID  CompanyAds
        /// or
        /// UNEXPECTED EXCEPTION WHILE Geting By ID CompanyAds
        /// </exception>
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
        /// <summary>
        /// Updates the company ad.
        /// </summary>
        /// <param name="toUpdauteCompanyAd">To updaute company ad.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="DataProviderException">
        /// ERROR WHILE Updating CompanyAd
        /// or
        /// UNEXPECTED EXCEPTION WHILE Updating CompanyAd
        /// </exception>
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