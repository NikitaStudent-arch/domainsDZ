using domainsDZ.DBcontext;
using domainsDZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domainsDZ
{
    public class CRUD
    {
        public CRUD() { }
        public List<User> ReadUsers()
        {
            using (var db = new DBcontext())
            {
                return db.Users.ToList();
            }
        }

        public void UpdateUser(int id, string name, string email)
        {
            using (var db = new DBcontext())
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    user.Name = name;
                    user.Email = email;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteUser(int id)
        {
            using (var db = new DBcontext())
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public int CreateUser(string name, string email)
        {
            using (var db = new DBcontext())
            {
                var user = new User { Name = name, Email = email };
                db.Users.Add(user);
                db.SaveChanges();
                return user.Id;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain_1 = AppDomain.CreateDomain("domain_1");
            CRUD crud = (CRUD)domain_1.CreateInstanceAndUnwrap(typeof(CRUD).Assembly.FullName, typeof(CRUD).FullName);
        }
    }
}
