namespace MiniServer.Extensions
{
    public class StringExtensions
    {
        static public string Capitalize(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1, name.Length - 1).ToLower();
        }
    }
}
