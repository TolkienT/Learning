namespace SignalRChat
{
    public class TestHandler
    {
        public static async Task<List<Model>> GetWeighBridgeAlarm()
        {
            List< Model > list = new List<Model>();
            list.Add(new Model()
            {
                Name = "Test",
            });
            return list;
        }
    }

    public class Model
    {
        public string Name { get; set; }
    }
}
