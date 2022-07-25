using User_API.Model;

namespace User_API.Repo
{
    public class User_Repo : IUser_Repo
    {
        private List<Users> Users { get; set; }
        private UserContext User_context;

        public User_Repo(UserContext context)
        {
            User_context = context;
        }

        public List<Users> GetAll()
        {
            List<Users> User;
           
                User = User_context.Set<Users>().ToList();
            
            return User;
        }

        public Users Get(int id)
        {
            Users Users;
            try
            {
                Users = User_context.Find<Users>(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Users;
        }

        public void Delete(int Id)
        {
            Users _temp = Get(Id);
            if (_temp != null)
            {
                User_context.Remove<Users>(_temp);
                User_context.SaveChanges();
            }
        }

        public void Ubdate(Users user)
        {
            Users _temp = Get(user.Id);
            if (_temp != null)
            {
                _temp.Id = user.Id;
                _temp.First_Name = user.First_Name;
                _temp.Last_Name = user.Last_Name;
                
                User_context.Update<Users>(_temp);
                User_context.SaveChanges();
            }

        }

        public void Add(Users user)
        {
            User_context.Add<Users>(user);
            User_context.SaveChanges();

        }
     }

    }


