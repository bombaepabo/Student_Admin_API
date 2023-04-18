namespace StudentAdmin_API.Repository
{
    public class LocalStorageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string filename)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\images",filename);
            using Stream FileStream = new FileStream(filePath,FileMode.Create);
            await file.CopyToAsync(FileStream);
            return GetServerRelativePath(filename);
        }
    private string GetServerRelativePath(string filename)
    {
        return Path.Combine(@"Resources\images", filename);
    }
    }
}
