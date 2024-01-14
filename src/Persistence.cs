using Newtonsoft.Json;

namespace BattleBoats
{
    class Save
    {
        public static void SaveGame(Data data)
        {
            File.Create(Constants.SaveGamePath).Close();
            string json = Json.Convert.SerialiseObject(data);
            File.WriteAllText(Constants.SaveGamePath, string.Empty);
            File.WriteAllText(Constants.SaveGamePath, json);
        }
    }

    class Load
    {
        public static Data LoadGame()
        {
            string json = File.ReadAllText(Constants.SaveGamePath);
            Data data = JsonConvert.DeserializeObject<Data>(json);
            return data;
        }
    }
}
