namespace StaySphere.Infrastructure.Services
{
 
    using Amazon.S3;
    using Amazon.S3.Model;
    using StaySphere.Application.Interfaces;
    using Microsoft.Extensions.Configuration;

    public class AwsService : IAwsService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public AwsService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"] ?? throw new ArgumentNullException(nameof(configuration), "AWS:BucketName configuration is missing");
        }

        public async Task<string> GeneratePreSignedUrlAsync(string key)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(15)
            };

            return _s3Client.GetPreSignedURL(request);
        }
    }
}