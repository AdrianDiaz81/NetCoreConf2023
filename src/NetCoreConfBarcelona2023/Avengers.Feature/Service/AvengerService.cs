using Avengers.API.Data;
using Avengers.API.Model;
using Microsoft.Extensions.Logging;

namespace Avengers.API.Service;

public class AvengerService : IAvengerService
{
    private readonly ILogger<AvengerService> _logger;    
    private readonly AvengerDbContext _dbContext;
    public AvengerService(ILogger<AvengerService> logger, AvengerDbContext dataContext)
    {
        this._logger=logger;
        this._dbContext=dataContext;

    }
    public async Task<AvengerCharacter> Get(string id)
    {
        _logger.LogInformation("Init Get");

        var result = this._dbContext.Avengers.Find(id);
        return result;
    }

    public async Task<IEnumerable<AvengerCharacter>> GetAll()
    {
        _logger.LogInformation("Init Get");
        var result = this._dbContext.Avengers.ToList();
        return result;
    }
}
