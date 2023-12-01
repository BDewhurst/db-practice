using MongoDataAccess.Models;
using MongoDataAccess.DataAccess;

ChoreDataAccess db = new ChoreDataAccess();


UserData userData = new UserData();
List<UserModel> userList = userData.UserList;

await db.DeleteAllUsers();
await db.CreateMultipleUsers(userList);
var users = await db.GetAllUsers();
ChoreData choreData = new ChoreData();
List<ChoreModel> choreList = choreData.ChoreList;


Random random = new Random();
userList = userList.OrderBy(x => random.Next()).ToList();

foreach (var chore in choreList)
{

    chore.AssignedTo = userList[random.Next(userList.Count)];
}

await db.DeleteAllChores();
await db.CreateMultipleChores(choreList);
  List<ChoreHistoryModel> choreHistoryList = new List<ChoreHistoryModel>();
 
 foreach (ChoreModel chore in choreList)
            {
                ChoreHistoryModel history = new ChoreHistoryModel(chore);
                choreHistoryList.Add(history);
            }

await db.DeleteAllChoresHistory();
await db.CreateMultipleChoresHistory(choreHistoryList);
