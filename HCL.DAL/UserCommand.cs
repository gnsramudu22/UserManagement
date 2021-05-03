using HCL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCL.DAL
{
    
    public class UserCommand : IDisposable
    {

        public List<User> GetAll()
        {
            
            using (Database db = new Database())
            {
                var query = "SELECT UserId, FirstName, LastName, Email, IsActive FROM User";

                DataTable dt = db.Execute(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return null;
                }
                List<User> users = new List<User>();
                foreach(DataRow dr in dt.Rows)
                {
                    users.Add(new User
                    {
                        UserId = Convert.ToString(dt.Rows[0]["UserId"]),
                        FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                        LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                        Email = Convert.ToString(dt.Rows[0]["Email"]),
                        IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"])
                    });
                }
                return users;
            }
        }

        public User GetByUserID(string userID)
        {
            using (Database db = new Database())
            {
                var query = "SELECT UserId, PCode, FirstName, LastName, Email, IsActive FROM User WHERE UserId = @id";

                var args = new Dictionary<string, object>
                {
                    {"@id", userID}
                };

                DataTable dt = db.Execute(query, args);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return null;
                }

                var user = new User
                {
                    UserId = Convert.ToString(dt.Rows[0]["UserId"]),
                    PCode = Convert.ToString(dt.Rows[0]["PCode"]),
                    FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                    LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"])
                };

                return user;
            }
        }

        public bool Save(User newObj)
        {
            using (Database db = new Database())
            {
                const string query = "INSERT INTO User(UserId, PCode, FirstName, LastName, Email, IsActive) VALUES(@UserId, @Password,@FirstName, @LastName, @Email, true)";

                //here we are setting the parameter values that will be actually 
                //replaced in the query in Execute method
                var args = new Dictionary<string, object>
                {
                    {"@UserId", newObj.UserId},
                    {"@Password", newObj.PCode},
                    {"@FirstName", newObj.FirstName},
                    {"@LastName", newObj.LastName},
                    {"@Email", newObj.Email}
                };

                return db.ExecuteWrite(query, args) > 0;
            }
        }

        public bool Update(User newObj)
        {
            using (Database db = new Database())
            {
                const string query = "UPDATE User SET FirstName = @FirstName, LastName = @LastName, Email = @Email, IsActive = @IsActive WHERE UserId = @UserId";

                //here we are setting the parameter values that will be actually 
                //replaced in the query in Execute method
                var args = new Dictionary<string, object>
                {
                    {"@UserId", newObj.UserId},
                    {"@FirstName", newObj.FirstName},
                    {"@LastName", newObj.LastName},
                    {"@Email", newObj.Email},
                    {"@IsActive", newObj.IsActive}
                };

                return db.ExecuteWrite(query, args) > 0;
            }
        }
        public bool Delete(string userID)
        {
            using (Database db = new Database())
            {
                const string query = "Delete from User WHERE UserId = @id";

                var args = new Dictionary<string, object>
                {
                    {"@id", userID}
                };

                return db.ExecuteWrite(query, args) > 0;
            }
        }


        public bool ValidateLogin(string userId, string password)
        {
            using (Database db = new Database())
            {
                var query = "SELECT UserId FROM User WHERE UserId = '@UserId' AND PCode = '@Password'";

                var args = new Dictionary<string, object>
                {
                    {"@UserId", userId},
                    {"@Password", password}
                };

                DataTable dt = db.Execute(query, args);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return false;
                }

                var user = new User
                {
                    UserId = Convert.ToString(dt.Rows[0]["UserId"])
                };

                return user != null;
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
