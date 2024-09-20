using Microsoft.EntityFrameworkCore;
using RunningActivity.Models;

namespace RunningActivity.Services
{
    public class WebConfigService(AppDbContext dbContext)
    {
        public async Task<WebConfig?> GetWebConfigAsync(string key)
        {
            return await dbContext.WebConfigs.FirstOrDefaultAsync(w => w.Key == key);
        }

        public async Task<WebConfig> SetWebConfigAsync(string key, string value)
        {
            var webConfig = await dbContext.WebConfigs.FirstOrDefaultAsync(w => w.Key == key);
            if (webConfig == null)
            {
                webConfig = new() { Key = key, Value = value };
                dbContext.WebConfigs.Add(webConfig);
            }
            else
            {
                webConfig.Value = value;
            }
            await dbContext.SaveChangesAsync();
            return webConfig;
        }
    }
}
