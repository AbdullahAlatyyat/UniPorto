using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using System.Configuration;
using System.IO;

namespace Uni_Porto_BlobStoage
{
    public class BlobManager
    {
        public CloudStorageAccount storageAccount
        {
            get;
            set;
        }

        public BlobManager()
        {
            // Retrieve storage account from connection string.
            //storageAccount = CloudStorageAccount.Parse
            //    (ConfigurationManager.AppSettings["StorageConnectionString"]);
            string AccountName = "uniporto";
            string AccountKey = "Gf1qqgtYZLD6AtY0vwVKaYYU9EYFPr6E5/dGKxxnRpXOO7zdVd2lElMzfyoBPCMp2q1KT1vwQX9yqaPYceQBmw==";
            string UserConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", AccountName, AccountKey);
            storageAccount = CloudStorageAccount.Parse(UserConnectionString);

        }

        public void CreateContianer(string contianerName)
        {
            try
            {
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                // Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference(contianerName);
                // Create the container if it doesn't already exist.
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string UploadBlob(FileBlob FileToUplode)
        {
            try
            {
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference(FileToUplode.ContianerName);
                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileToUplode.FileGuidId);
                blockBlob.Properties.ContentType=FileToUplode.ContentType;
                blockBlob.UploadFromStream(FileToUplode.FileStream);
                return blockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        public List<string> GetContainerList(string containerName)
        {
            List<string> blobList = new List<string>();

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, true))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobList.Add(blob.Uri.ToString());
                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;
                    blobList.Add(directory.Uri.ToString());
                }


            }
            return blobList;
        }

        public MemoryStream DownloadBlob(string containerName, string fileName)
        {
            try
            {

                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                // Retrieve reference to a blob named "photo1.jpg".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

                var memoryStream = new System.IO.MemoryStream();
                blockBlob.DownloadToStream(memoryStream);

                return memoryStream;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool DeleteBlob(string containerName, string blobName)
        {
            bool isDeleted = false;
            try
            {
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                // Retrieve reference to a blob named "myblob.txt".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

                // Delete the blob.
                blockBlob.Delete();

                return isDeleted = true;
            }
            catch (Exception ex)
            {

                return isDeleted;
            }
        }

        //public string CreateAccessPolicy(string containerName)
        //{
        //    // Create the blob client object.
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        //    // Get a reference to the container for which shared access signature will be created.
        //    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        //    container.CreateIfNotExists();

        //    // Get the current permissions for the blob container.
        //    BlobContainerPermissions blobPermissions = container.GetPermissions();

        //    // Clear the container's shared access policies to avoid naming conflicts.
        //    blobPermissions.SharedAccessPolicies.Clear();

        //    // The new shared access policy provides read/write access to the container for 24 hours.
        //    blobPermissions.SharedAccessPolicies.Add("mypolicy", new SharedAccessBlobPolicy()
        //    {
        //        // To ensure SAS is valid immediately, don’t set the start time.
        //        // This way, you can avoid failures caused by small clock differences.
        //        SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
        //        Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Add
        //    });

        //    // The public access setting explicitly specifies that
        //    // the container is private, so that it can't be accessed anonymously.
        //    blobPermissions.PublicAccess = BlobContainerPublicAccessType.Off;

        //    // Set the new stored access policy on the container.
        //    container.SetPermissions(blobPermissions);

        //    // Get the shared access signature token to share with users.
        //    string sasToken =
        //       container.GetSharedAccessSignature(new SharedAccessBlobPolicy(), "mypolicy");
        //}
    }
}
