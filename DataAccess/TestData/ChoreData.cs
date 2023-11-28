
namespace MongoDataAccess.Models
{
    public class ChoreData
    {
        public List<ChoreModel> ChoreList { get; } = new List<ChoreModel>
        {
            new ChoreModel {ChoreText = "Take out the bins", FrequencyInDays ="7" } ,
            new ChoreModel {ChoreText = "Wash the dishes", FrequencyInDays = "1"} , 
            new ChoreModel {ChoreText = "Hoover the floors", FrequencyInDays = "2"} ,
            new ChoreModel {ChoreText = "Mow the lawn", FrequencyInDays = "14"} 
        };
    }
}

