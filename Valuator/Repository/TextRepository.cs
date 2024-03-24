using StackExchange.Redis;

namespace Valuator.Repository
{
    public class TextRepository : ITextRepository
    {
        private readonly ConnectionMultiplexer _redis; 

        public TextRepository() 
        {            
            _redis = ConnectionMultiplexer.Connect("localhost:6379");
        }
        public void Add(string id, string data)
        {
            var db = _redis.GetDatabase();
            db.StringSet(id, data);           
            //throw new NotImplementedException();
        }

        public int CheckSimilarity(string id)
        {
            var db = _redis.GetDatabase();
            var endPoint = _redis.GetEndPoints().First();
            var allKeys = _redis.GetServer(endPoint).Keys().ToList();
            var allText = allKeys.ConvertAll(k => db.StringGet(k));
            var text = db.StringGet(id);
            var count = allText.Count(t => t == text);
            return count >= 2 ? 1 : 0;
            //throw new NotImplementedException();
        }

        public string? Get(string id)
        {
            var db = _redis.GetDatabase();
            return db.StringGet(id);
            ///throw new NotImplementedException();
        }
    }
}
