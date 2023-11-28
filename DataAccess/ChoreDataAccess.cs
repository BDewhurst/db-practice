using Amazon.Runtime.Internal;
using MongoDataAccess.Models;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

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
    private async Task<List<UserModel>>GetAllUsers() 
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
}
