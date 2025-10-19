using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoriesContracts
{
    public interface IUsersRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword( string email, string password);
        Task<ApplicationUser?> GetUserByUserID(Guid? userID);
    }
}
