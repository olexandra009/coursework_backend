using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IUploadMultimediaService
    {
        Task<string> UploadImage(string imageBase64, string folderName, string imageName);
        Task DeleteImageFromS3(string url);
    }
    public class UploadMultimediaService : IUploadMultimediaService
    {
        private readonly IConfigurationSection _configuration;

        public UploadMultimediaService(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("S3Credentials");
        }

        public async Task DeleteImageFromS3(string url)
        {
            var bucketName = _configuration["BucketName"];
            var accessKeyId = _configuration["AccessKeyId"];
            var secretKey = _configuration["SecretKey"];
            string keyName = GetKeyName(url);
            var bucketRegion = RegionEndpoint.USEast2;
            var s3Client = new AmazonS3Client(accessKeyId, secretKey, bucketRegion);

            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };

               var response =  await s3Client.DeleteObjectAsync(deleteObjectRequest);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
        }

        private string GetKeyName(string url)
        {
            //url = https://{bucket_name}{region}/{folder}/{file_name}
            var res = url.Split('/');
            string key = res[3] + "/" + res[4];
            return key;
        }

        public async Task<string> UploadImage(string imageBase64, string folderName, string imageName)
        {
            var bucketName = _configuration["BucketName"];
            var accessKeyId = _configuration["AccessKeyId"];
            var secretKey = _configuration["SecretKey"];

            var bucketRegion = RegionEndpoint.USEast2;
            var s3Client = new AmazonS3Client(accessKeyId, secretKey, bucketRegion);

            var bytes = Convert.FromBase64String(imageBase64);

            try
            {
                using (s3Client)
                {
                    var request = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        CannedACL = S3CannedACL.PublicRead,
                        Key = $"{folderName}/{imageName}"
                    };
                    await using (var ms = new MemoryStream(bytes))
                    {
                        request.InputStream = ms;
                        await s3Client.PutObjectAsync(request);
                    }
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an image", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an image", e.Message);
            }

            var uri = $"https://{bucketName}.s3.us-east-2.amazonaws.com/{folderName}/{imageName}";
            return uri;
        }
    }
}
