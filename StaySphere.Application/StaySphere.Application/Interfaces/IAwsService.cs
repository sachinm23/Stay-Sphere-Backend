namespace StaySphere.Application.Interfaces
{
    public interface IAwsService
    {
        Task<string> GeneratePreSignedUrlAsync(string key);
    }
}