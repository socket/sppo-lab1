using System;

/* 6.
 * если заданная квадратная целочисленная матрица является треугольной  (эл-ты выше побочной диаг. == 0), вычислить ее ср. арифм.
 * Иначе, определить сколько эл-тов выше главной диаг отличны от нуля.
 * */
namespace Lab1
{
  public class LabTask6 : LabTask
  {
  #region --
    public override int Id {
      get { return 6; }
    }

    public override string Author
    {
      get { return "Nastya Dudkina"; }
    }
    #endregion
    public override void Do() {
      Matrix m = Matrix.ReadFromConsole();
      Console.WriteLine(m);
      if (! m.IsSquare ) {
        Console.WriteLine("Matrix is not square, try again");
        Do();
        return;
      }
      if ( m.IsTriangle ) {
        Console.WriteLine("Matrix mean value: {0}", m.MeanValue);
      }
      else {
        int count = 0;
        for (int i=0; i<m.Rows-1; i++) {
          for (int j=0; j<m.Columns-i-1; j++) {
            if (m[i, j] != 0) {
              count++;
            }
          }
        }
        Console.WriteLine("Not null element count is {0}", count);
      }
    }
  }
}
