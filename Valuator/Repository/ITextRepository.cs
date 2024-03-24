namespace Valuator.Repository
{
    public interface ITextRepository
    {
        string? Get(string id);
        void Add(string id, string data);
        int CheckSimilarity(string id);
        //string GetSimilarity(string id);
    }
}
