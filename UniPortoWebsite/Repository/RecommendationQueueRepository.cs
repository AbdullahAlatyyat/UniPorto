using GraduationProject.UniPortoWebsite.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository.Context;

namespace UniPortoWebsite.Repository
{
    public class RecommendationQueueRepository
    {
        public int AddOnQueue(RecommendationQueue queue)
        {
            try
            {
                int added = -1;
                using (var context = new UniPorto())
                {
                    context.RecommendationQueue.Add(queue);
                    context.SaveChanges();
                    added = queue.Id;
                }
                return added;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE ADDING ON QUEUE", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE ADDING ON QUEUE", ex);
            }
        }

        public List<RecommendationQueue> GetQueueByInstructorId(int InstructorId)
        {
            try
            {
                var list = new List<RecommendationQueue>();
                using (var context = new UniPorto())
                {
                    list = context.RecommendationQueue.Where(p => p.InstructorId == InstructorId).ToList();
                }
                return list.OrderByDescending(o=>o.CreateOn).ToList();
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING FROM QUEUE", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING FROM QUEUE", ex);
            }
        }

        public bool DeleteFromQueueByInstructor(int queueId)
        {
            try
            {
                bool deleted = false;
                using (var context = new UniPorto())
                {
                    var temp = context.RecommendationQueue.Find(queueId);
                    context.RecommendationQueue.Remove(temp);
                    context.SaveChanges();
                    deleted = true;
                }
                return deleted;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE DELETEING FROM QUEUE", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE DELETEING FROM QUEUE", ex);
            }
        }
        public RecommendationQueue GetQueueByRequestId(int RequestId)
        {
            try
            {
                var list = new RecommendationQueue();
                using (var context = new UniPorto())
                {
                    list = context.RecommendationQueue.Include(pr => pr.Profile).Include(p=>p.Activity).Where(p => p.Id == RequestId).SingleOrDefault();
                }
                return list;
            }
            catch (SqlException sqlex)
            {
                throw new DataProviderException("ERROR WHILE GETTING FROM QUEUE", sqlex);
            }
            catch (Exception ex)
            {
                throw new DataProviderException("UNEXPECTED EXCEPTION WHILE GETTING FROM QUEUE", ex);
            }
        }
        //GetQueueByActivityId
    }
}