using Avengers.API.Model;

namespace Avengers.API.Service;

public interface IAvengerService
{
    Task<IEnumerable<AvengerCharacter>> GetAll();
    Task<AvengerCharacter> Get(string id);        

}
