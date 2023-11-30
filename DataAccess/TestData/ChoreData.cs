using System;

namespace MongoDataAccess.Models
{
    public class ChoreData
    {
        public List<ChoreModel> ChoreList { get; } = new List<ChoreModel>
        {
            new ChoreModel {ChoreText = "Take out the bins", FrequencyInDays ="7", LastCompleted= DateTime.UtcNow} ,
            new ChoreModel {ChoreText = "Wash the dishes", FrequencyInDays = "1", LastCompleted= DateTime.UtcNow} , 
            new ChoreModel {ChoreText = "Hoover the floors", FrequencyInDays = "2", LastCompleted= DateTime.UtcNow.AddDays(-3)} ,
            new ChoreModel {ChoreText = "Mow the lawn", FrequencyInDays = "14", LastCompleted= DateTime.UtcNow.AddDays(-1)} 
        };
    }
}

