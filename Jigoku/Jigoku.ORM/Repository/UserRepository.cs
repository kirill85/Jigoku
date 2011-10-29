using Jigoku.Core.Entities;
using NHibernate;

namespace Jigoku.ORM.Repository
{
    public class UserRepository
    {

        public UserRepository()
        {
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

        public void AddUser(ref string nickName, ref string password, ref string PrimaryMail, ref byte[] userPhoto = null)
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
    }
}
