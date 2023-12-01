
using System.Reflection.Metadata;
using MongoDataAccess.Models;
using MongoDB.Driver;


namespace MongoDataAccess.DataAccess;
public class ChoreDataAccess
{
    private readonly string ConnectionString = GetConnectionString();
    private const string DatabaseName = "choredb"; 
    private const string ChoreCollection = "chore_chart";

    private const string UserCollection = "users";
    private const string ChoreHistoryCollection = "chore_history";

            private static string GetConnectionString()
        {
            string envConnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
            
          
            return string.IsNullOrEmpty(envConnectionString) ? "mongodb://localhost:27017" : envConnectionString;
        }

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

public async Task DeleteAllChores() {
    var choresCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
    await choresCollection.DeleteManyAsync(_ => true);
}
public Task CreateMultipleChores(IEnumerable<ChoreModel> chores) {
    var choresCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
    return choresCollection.InsertManyAsync(chores);
}

public Task CreateMultipleChoresHistory(IEnumerable<ChoreHistoryModel> chores) {
    var choresHistoryCollection = ConnectToMongo<ChoreHistoryModel>(ChoreHistoryCollection);
    return choresHistoryCollection.InsertManyAsync(chores);
}

public async Task DeleteAllChoresHistory() {
    var choresHistoryCollection = ConnectToMongo<ChoreHistoryModel>(ChoreHistoryCollection);
    await choresHistoryCollection.DeleteManyAsync(_ => true);
}

public async Task CompleteChore(ChoreModel chore) {
    var choresCollection = ConnectToMongo<ChoreModel>(ChoreCollection);
    var filter = Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
    await choresCollection.ReplaceOneAsync(filter, chore);
    var choreHistoryCollection = ConnectToMongo<ChoreHistoryModel>(ChoreHistoryCollection);
    await choreHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));
}

}



