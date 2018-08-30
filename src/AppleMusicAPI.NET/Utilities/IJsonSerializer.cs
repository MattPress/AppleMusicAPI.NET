namespace AppleMusicAPI.NET.Utilities
{
    public interface IJsonSerializer
    {
        string Serialize(object request);
        T Deserialize<T>(string response);
    }
}