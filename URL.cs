using System.Net;
using System.Text.RegularExpressions;

namespace URLObfuscator;

public class URL
{
  public string Full { get; set; }
  public string Protocol { get; set; }
  public string Domain { get; set; }
  public string Path { get; set; }

  public URL(string url, string choice)
  {
    string[] ProtocolSplit = url.Split("//");
    string[] DomainPathSplit = ProtocolSplit[1].Split("/", 2);
    Full = url;
    Protocol = ProtocolSplit[0] + "//";
    Domain = DomainPathSplit[0];
    Path = "/" + DomainPathSplit[1];

    switch (choice)
    {
      case "all":
        // run all
        break;
      default:
        //octal 32 bits
        break;
    }
  }

  public static bool IsUrl(string input)
  {
    string pattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    var rx = new Regex(pattern);
    Match result = rx.Match(input);

    return result.Success;
  }

  string DummyHTTPBasicAuth(string username = "user")
    => Protocol + username + "@" + Domain + Path;

  string EightBitDecimal()
  {
    IPHostEntry hostInfo = Dns.GetHostEntry(Domain);
    string ip = hostInfo.AddressList[0].ToString();
    return Protocol + ip + Path;
  }
}
