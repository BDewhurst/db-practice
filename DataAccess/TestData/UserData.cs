
namespace MongoDataAccess.Models
{
    public class UserData
    {
        public List<UserModel> UserList { get; } = new List<UserModel>
        {
            new UserModel { FirstName = "John", LastName = "Doe" },
            new UserModel { FirstName = "Jane", LastName = "Smith"},
            new UserModel { FirstName = "Frank", LastName = "Smith"},
            new UserModel { FirstName = "Ian", LastName = "Smith"},
        };
    }
}

