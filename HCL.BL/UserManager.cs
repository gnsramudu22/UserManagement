using HCL.DAL;
using HCL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.BL
{
    public class UserManager : IDisposable
    {
        

        public List<User> GetAll()
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.GetAll();
            }
        }

        public User GetByID(string id)
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.GetByUserID(id);
            }
        }

        public bool ValidateLogin(string userId, string password)
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.ValidateLogin(userId, password);
            }
        }

        public bool Save(User newObj)
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.Save(newObj);
            }
        }

        public bool Update(User modObj)
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.Update(modObj);
            }
        }
        public bool Delete(string id)
        {
            using (UserCommand cmd = new UserCommand())
            {
                return cmd.Delete(id);
            }
        }
        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
