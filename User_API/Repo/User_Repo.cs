using User_API.Model;

namespace User_API.Repo
{
    public class User_Repo
    {
        static List<Users> user_list { get; set; }

        static User_Repo()
        {
            user_list = new List<Users>()
            {
                new Users() { Id = 1, First_Name = "Aya", Last_Name = "Dar Ali Hussain"},
                new Users() { Id = 2, First_Name = "Weam", Last_Name = "Hjaji"},
                new Users() { Id = 3, First_Name = "Ala", Last_Name = "Sawada"},
                new Users() { Id = 4, First_Name = "Israa", Last_Name = "Haseeba"},
                new Users() { Id = 5, First_Name = "Mohammad", Last_Name = "Ahmad"}

            };

        }

        public static List<Users> GetAll()
        {
            return user_list;
        }

        public static Users Get(int id)
        {
            return user_list.FirstOrDefault(userr => userr.Id == id);
        }

        public static void Delete(int id)
        {
            var user_del = Get(id);
            if (user_del != null)
                user_list.Remove(user_del);
        }

        public static void Add(Users users)
        {
            user_list.Add(users);
        }

        public static void Ubdate(Users users)
        {
            var index = user_list.FindIndex(user_ubd => user_ubd.Id == users.Id);
            if (index == -1)
                return;
            user_list[index] = users;

        }
    }
}


