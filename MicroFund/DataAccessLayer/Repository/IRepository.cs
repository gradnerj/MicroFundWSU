using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository {
    public interface IRepository {

        #region CREATE Methods




        #endregion

        #region RETRIEVE Methods
        Task<IList<ApplicationUser>> GetAllUsersAsync();
        Task<Dictionary<string, string>> GetAllUserRolesAsync();

        Task<string> GetUserRoleAsync(string id);

        ApplicationUser GetUserById(string id);


        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion

    }
}
