using System;
using System.Collections.Generic;
using HCL.BL;
using HCL.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HCL.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        [TestMethod]
        public void TestGetAll()
        {
            using (UserManager mgr = new UserManager())
            {
                List<User> users = mgr.GetAll();
                Assert.IsNotNull(users);
            }
        }

        [TestMethod]
        public void TestGetByUserID()
        {
            using (UserManager mgr = new UserManager())
            {
                User user = mgr.GetByID("sitaram1");
                Assert.IsNotNull(user);
                Assert.AreEqual("sitaram1", user.UserId);
            }
        }

        [TestMethod]
        public void TestSave()
        {
            using (UserManager mgr = new UserManager())
            {
                User user = new User {
                    UserId = "sa",
                    PCode = "admin",
                    FirstName= "Sita Ramudu",
                    LastName = "G N ",
                    Email="sa@admin.com"
                };
                bool result = mgr.Save(user);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            using (UserManager mgr = new UserManager())
            {
                User user = new User
                {
                    UserId = "sitaram1",
                    PCode = "sitaram1",
                    FirstName = "Sita Ramudu",
                    LastName = "G N ",
                    Email = "abc@abc.com"
                };
                bool result = mgr.Update(user);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            using (UserManager mgr = new UserManager())
            {
                
                bool result = mgr.Delete("sitaram1");
                Assert.AreEqual(true, result);
            }
        }
    }
}
