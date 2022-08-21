namespace URLObfuscator;

class Program
{
  static void Main(string[] args)
  {
    Queue<string> argq = new Queue<string>(args);

    string choice = argq.Dequeue();


    while (argq.Count > 0)
    {
      string arg = argq.Dequeue();
      if (!URL.IsUrl(arg)) continue;
      URL url = new URL(arg, choice);
    }
  }
}