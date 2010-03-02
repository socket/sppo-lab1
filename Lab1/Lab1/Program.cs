using System;

namespace Lab1 {
  internal class Program {
    public static LabTask Task = new LabTask23();
    
    private static void Main(string[] args) {
      Console.WriteLine("Lab1.{0}", Task.Id);
      Console.WriteLine("{0}, A-13-07\n", Task.Author);
      Task.Do();

      Console.ReadLine();
    }
  }
}
