using System.Text;

namespace AspNetLinq.Utils;

public class Utils
{
    public static string UnderCase =>new string(Enumerable.Range('a','z'-'a'+1).Select(x => (char)x).ToArray());
    public static string UpperCase => new string(Enumerable.Range('A','Z'-'A'+1).Select(x => (char)x).ToArray());
    public static string NumbersRange = new string(Enumerable.Range('0','9'-'0'+1).Select(x => (char)x).ToArray());

    public static string Generate20LenghtCode()
    {
        var strbuilder = new StringBuilder();
        string chars = UnderCase+UpperCase+NumbersRange;
        var i = 0;
        while (i < 20)
        {
            var random = new Random();
            var charap=chars[random.Next(0, chars.Length-1)];
            strbuilder.Append(charap);
            i++;
        }
        return strbuilder.ToString();
    }
}