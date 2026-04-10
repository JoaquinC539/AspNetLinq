using System.Text;

namespace AspNetLinq.Utils;

public class Utils
{

    public static readonly string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
    private static readonly Random random = new();

    public static string Generate20LenghtCode()
    {
        var strbuilder = new StringBuilder();
        var i = 0;
        while (i < 20)
        {
            var charap=Chars[random.Next(0, Chars.Length-1)];
            strbuilder.Append(charap);
            i++;
        }
        return strbuilder.ToString();
    }
}