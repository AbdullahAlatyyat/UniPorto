using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace UniPortoPhoneStroage
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
            string AccountName = "uniporto";
            string AccountKey = "Gf1qqgtYZLD6AtY0vwVKaYYU9EYFPr6E5/dGKxxnRpXOO7zdVd2lElMzfyoBPCMp2q1KT1vwQX9yqaPYceQBmw==";
            string UserConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", AccountName, AccountKey);
            storageAccount = CloudStorageAccount.Parse(UserConnectionString);
        }

        public async Task<Boolean> CreateContianer(string contianerName)
        {
            try
            {
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                // Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference(contianerName);
                // Create the container if it doesn't already exist.
                await container.CreateIfNotExistsAsync();
                await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadImageAsync(StorageFile file, string BlobFile, string contname)
        {
            try
            {
                Stream stream = await file.OpenStreamForReadAsync();

                // Create the blob client.
                CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                CloudBlobContainer Container = BlobClient.GetContainerReference(contname);

                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob BlockBlob = Container.GetBlockBlobReference(BlobFile);

                await BlockBlob.UploadFromStreamAsync(stream);

                return BlockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> UploadBlob(string contianerName, string blobFile, FileStream fileStream)
        {
            try
            {
                // Create the blob client.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Retrieve reference to a previously created container.
                CloudBlobContainer container = blobClient.GetContainerReference(contianerName);

                // Retrieve reference to a blob named "myblob".
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobFile);

                await blockBlob.UploadFromStreamAsync(fileStream);
                return blockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                blockBlob.DownloadToStreamAsync(memoryStream);

                return memoryStream;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<Boolean> DeleteBlob(string containerName, string blobName)
        {
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Retrieve reference to a blob named "myblob.txt".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

            // Delete the blob.
            await blockBlob.DeleteAsync();
            return true;
        }

    }
}
