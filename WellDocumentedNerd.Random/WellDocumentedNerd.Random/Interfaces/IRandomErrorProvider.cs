namespace WellDocumentedNerd.Random.Interfaces
{
    public interface IRandomErrorProvider
    {
        bool ReturnError(int min, int max, int threshold);
    }
}