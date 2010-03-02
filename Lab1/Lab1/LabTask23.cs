using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 23. из прямоуг матрицы исключить столбец с макс числом нулевых эл-тов 
 * сохранив все остальные элт-ты матрицы в том же порядке */
namespace Lab1
{
  public class LabTask23 : LabTask
  {
    public override int Id {
      get { return 23; }
    }

    public override string Author {
      get { return "Alexey Streltsow (alexey@zilanetworks.com)"; }
    }

    public override void Do() {
      Matrix m = Matrix.ReadFromConsole();
      Console.WriteLine(m);
      Matrix tm = m.Transpose();

      int colId = -1;
      int maxCount = 0;
      int col = 0;
      foreach(double[] row in tm) {
        int count = 0;
        foreach(double element in row) {
          if ( element == 0 ) {
            ++count;
          }
        }
        if ( count > maxCount ) {
          colId = col;
          maxCount = count;
        }
        col++;
      }
      --col;
      
      if ( col >= 0 ) {
        Console.Write("Removing column {0} with count {1}\n", colId, maxCount);
        Matrix rm = tm.RemoveRow(colId).Transpose();
        
        Console.WriteLine(rm);
      }
      else {
        Console.WriteLine("No column with null elements");
      }
    }
  }
}
