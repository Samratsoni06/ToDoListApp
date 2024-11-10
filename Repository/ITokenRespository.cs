using Microsoft.AspNetCore.Identity;

namespace ToDoListApp.Repository
{
    public interface ITokenRespository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
