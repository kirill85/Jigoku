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
            ConfigureRepository.Init();
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
                else return null;
            }
            return null;
        }

        public void AddUser(string nickName, string password, string PrimaryMail, string userPhoto = null)
        {
            if (!IsDuplicateNickname(nickName))
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
                        try
                        {
                            session.Save(newUser);
                            users.Add(newUser);
                            transaction.Commit();
                        }
                        catch (HibernateException)
                        {
                            transaction.Rollback();
                        }                        
                    }
                }
            }
            else throw new DuplicateValueException();
        }

        public void ChangePassword(string userNickname, string oldPassword, string newPassword)
        {
            using (var session = ConfigureRepository.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var user = findUserByName(userNickname);
                    var modifyUser = user;
                    try
                    {
                        if (oldPassword != newPassword)
                        {
                            modifyUser.Password = newPassword;
                        }
                        session.SaveOrUpdate(modifyUser);
                        transaction.Commit();
                        users.Remove(user);
                        users.Add(modifyUser);
                    }
                    catch (HibernateException)
                    {
                        transaction.Rollback();
                    }
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
    }
}
