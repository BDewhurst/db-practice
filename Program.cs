using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;

ChoreDataAccess db = new ChoreDataAccess();


UserData userData = new UserData();
List<UserModel> userList = userData.UserList;

await db.DeleteAllUsers();
await db.CreateMultipleUsers(userList);
var users = await db.GetAllUsers();

