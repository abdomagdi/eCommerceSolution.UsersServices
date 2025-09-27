using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    public class UsersRepository(DapperDbContext _dbContext) : IUsersRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            string query= "INSERT INTO public.\"Users\"  (\"UserID\", \"PersonName\", \"Email\", \"Password\", \"Gender\") " +
                "VALUES (@UserID, @PersonName, @Email, @Password, @Gender)";

            int rowCountAffected= await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            return null;
            
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
        {
            
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parameters = new { Email = email, Password = password };
            ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
            return user;
            //return  new ApplicationUser() {
            //    UserID = Guid.NewGuid(),
            //    PersonName="Person Name",
            //    Email = email,
            //    Password = password,
            //    Gender=GenderOptions.Male.ToString(),               
            //};
        }
    }
}
