using DnsClient.Protocol;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;
using MongoDBDemo;

string connectionString = "";
string databaseName = "simple_db";
string collectionsName = "people";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<PersonModel>(collectionsName);

var person = new PersonModel {FirstName ="Tim", LastName = "Corey"};
await collection.InsertOneAsync(person);
var results = await collection.FindAsync(_ => true);
foreach ( var result in results.ToList()) {
Console.WriteLine($"{result.Id} : {result.FirstName} {result.LastName}");
}

