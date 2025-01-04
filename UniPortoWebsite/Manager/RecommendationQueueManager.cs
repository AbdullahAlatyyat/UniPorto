using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniPortoWebsite.EF;
using UniPortoWebsite.Repository;

namespace UniPortoWebsite.Manager
{
    /// <summary>
    /// Class RecommendationQueueManager.
    /// </summary>
    public static    class RecommendationQueueManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        static RecommendationQueueRepository  repository = new RecommendationQueueRepository();
        /// <summary>
        /// Adds the on queue.
        /// </summary>
        /// <param name="queue">The queue.</param>
        /// <returns>System.Int32.</returns>
        public static int AddOnQueue(RecommendationQueue queue)
        {
            return repository.AddOnQueue(queue);
        }
        /// <summary>
        /// Gets the queue by instructor identifier.
        /// </summary>
        /// <param name="InstructorId">The instructor identifier.</param>
        /// <returns>List&lt;RecommendationQueue&gt;.</returns>
        public static List<RecommendationQueue> GetQueueByInstructorId(int InstructorId)
        {
            return repository.GetQueueByInstructorId(InstructorId);
        }
        /// <summary>
        /// Deletes from queue by instructor.
        /// </summary>
        /// <param name="queueId">The queue identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool DeleteFromQueueByInstructor(int queueId)
        {
            return repository.DeleteFromQueueByInstructor(queueId);
        }
        public static RecommendationQueue GetQueueByRequestId(int RequestId)
        {
            return repository.GetQueueByRequestId(RequestId);
        }
    }
}