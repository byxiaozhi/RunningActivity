using Microsoft.EntityFrameworkCore;
using RunningActivity.Models;

namespace RunningActivity.Services
{
    public class LocalFileService(AppDbContext dbContext, IConfiguration configuration)
    {
        public string LocalFileDirectory { get; } = configuration["LocalFileDirectory"] ?? throw new Exception("LocalFileDirectory not found in configuration");

        public async Task<LocalFile> CreateLocalFileAsync(Stream fileStream)
        {
            var fileName = Guid.NewGuid().ToString();
            var location = Path.Combine(LocalFileDirectory, fileName);
            using (var file = File.Create(location))
            {
                await fileStream.CopyToAsync(file);
            }
            var localFile = new LocalFile
            {
                Location = fileName
            };
            dbContext.LocalFiles.Add(localFile);
            await dbContext.SaveChangesAsync();
            return localFile;
        }

        public async Task DeleteLocalFileAsync(Guid id)
        {
            var localFile = await dbContext.LocalFiles.FirstOrDefaultAsync(l => l.Id == id) ?? throw new ArgumentException("Local file not found", nameof(id));
            var location = Path.Combine(LocalFileDirectory, localFile.Location);
            if (File.Exists(location))
            {
                File.Delete(location);
            }
            dbContext.LocalFiles.Remove(localFile);
            await dbContext.SaveChangesAsync();
        }

        public async Task<LocalFile?> GetLocalFileAsync(Guid id)
        {
            return await dbContext.LocalFiles.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<string?> GetLocalFileFullPathAsync(string location)
        {
            var localFile = await dbContext.LocalFiles.FirstOrDefaultAsync(l => l.Location == location);
            if (localFile == null)
            {
                return null;
            }
            return Path.Combine(LocalFileDirectory, location);
        }
    }
}
