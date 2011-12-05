using Jigoku.Core.Entities;
using NHibernate;
using System.Collections;
using System.Collections.Generic;

namespace Jigoku.ORM.Repository
{
    public class UserRepository
    {
        private List<User> users;

        public List<User> Users
        {
            get
            {
                return users;
            }
        }

        public UserRepository()
        {
            users = new List<User>();
            //ConfigureRepository.ConfigureRepository();
        }

        private bool IsDuplicateNickname(string nickName)
        {
            int nickCount = 0;
            using (var session = ConfigureRepository.SessionFactory.OpenSession())
            {
                nickCount = session.QueryOver<User>().Where(m => m.NickName == nickName).RowCount();
            }
            return (nickCount > 0);
        }

        private bool IsExistUser(string nickName)
        {
            return IsDuplicateNickname(nickName);
        }

        private User findUserByName(string nickname)
        {
            foreach (var user in users)
            {
                if (user.NickName == nickname)
                {
                    return user;
                }
                //else return null;
            }
            return null;
        }

        public bool AddUser(string nickName, string password, string PrimaryMail, string userPhoto = null)
        {           
               var newUser = new User();
               newUser.NickName = nickName;
               newUser.Password = password;
               newUser.PrimaryMail = PrimaryMail;
               newUser.UserPhoto = userPhoto;
               using (var session = ConfigureRepository.SessionFactory.OpenSession())
               {
                   using (var transaction = session.BeginTransaction())
                   {
                       if(session.Get<User>(newUser) != null)
                       {
                          session.Save(newUser);
                          users.Add(newUser);
                          transaction.Commit();
                          return true;
                       }
                   }
              }
              return false;
        }

        public void ChangePassword(string userNickname, string oldPassword, string newPassword)
        {
            using (var session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = findUserByName(userNickname);
                    var modifyUser = user;
                    if (oldPassword != newPassword)
                    {
                        modifyUser.Password = newPassword;
                    }
                    session.SaveOrUpdate(modifyUser);
                    transaction.Commit();
                    users.Remove(user);
                    users.Add(modifyUser);
                }
            }
        }

        public void DeleteUser(string userNickname)
        {
            using (var session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (IsExistUser(userNickname))
                    {
                        var user = findUserByName(userNickname);
                        session.Delete(user);
                        users.Remove(user);
                        transaction.Commit();
                    }
                }
            }
        }

        #region UserInfo
        public string GetUserNickname(int userId)
        {
            User user = null;
            using (var sx = ConfigureRepository.SessionFactory.GetCurrentSession())
            {
                using (var tx = sx.BeginTransaction())
                {
                    user = sx.Get<User>(userId);
                    tx.Commit();
                }
            }
            return user.NickName;
        }

        public string GetUserPhoto(int userId)
        {
            return null;
        }
        #endregion
    }
}
