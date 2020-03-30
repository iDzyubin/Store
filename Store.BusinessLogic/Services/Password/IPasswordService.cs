using System.Threading.Tasks;

namespace Store.BusinessLogic.Services.Password
{
    public interface IPasswordService
    {
        string GetHash( string password );

        bool ValidateHash( string password, string hashed );
    }
}