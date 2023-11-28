
using MongoDataAccess.Models;
using MongoDB.Driver;


namespace MongoDataAccess.DataAccess;
public class ChoreDataAccess
{
    private const string ConnectionString = "";
    private const string DatabaseName = "choredb"; 
    private const string ChoreCollection = "chore_chart";

    private const string UserCollection = "users";
    private const string ChoreHistoryCollection = "chore_history";

    private IMongoCollection<T> ConnectToMongo<T>(in string collection) {
        var client = new MongoClient(ConnectionString);
        var db = client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);
    }
    public async Task<List<UserModel>>GetAllUsers() 
    {
        var usersCollection = ConnectToMongo<UserModel>(UserCollection);
        var results = await usersCollection.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<List<ChoreModel>>GetAllChores() {
        var choresCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        var results = await choresCollection.FindAsync(_ => true);
        return results.ToList();

    }
    public async Task<List<ChoreModel>> GetAllChoresForAUser(UserModel user) {
        var choresCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
        var results = await choresCollection.FindAsync(c => c.AssignedTo.Id == user.Id);
        return results.ToList();
    }

    public Task CreateMultipleUsers(IEnumerable<UserModel> users) {
        var usersCollection = ConnectToMongo<UserModel>(UserCollection);
        return usersCollection.InsertManyAsync(users);
    }
    public async Task DeleteAllUsers()
{
    var usersCollection = ConnectToMongo<UserModel>(UserCollection);
    await usersCollection.DeleteManyAsync(_ => true);
}

}
