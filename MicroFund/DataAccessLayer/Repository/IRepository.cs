using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository {
    public interface IRepository {

        #region CREATE Methods
        #endregion

        #region RETRIEVE Methods
        Task<IList<IdentityUser>> GetAllUsersAsync();
        Task<Dictionary<string, string>> GetAllUserRolesAsync();
        #endregion

        #region UPDATE Methods
        #endregion

        #region DELETE Methods
        #endregion

    }
}
