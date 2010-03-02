using System;
using System.Collections;

namespace Lab1 {
  public class MatrixEnumerator : IEnumerator {
    public double[][] Values;
    private int _position = -1;

    public MatrixEnumerator(double[][] list) {
      Values = list;
    }

    public bool MoveNext() {
      _position++;
      return (_position < Values.Length);
    }

    public void Reset() {
      _position = -1;
    }

    public object Current {
      get {
        try {
          return Values[_position];
        }
        catch (IndexOutOfRangeException) {
          throw new InvalidOperationException();
        }
      }
    }
  }

  public class Matrix : IEnumerable {
    private readonly double[][] _data;
    
    public int Rows {
      get {
        return _data.Length;
      }
    }
    public int Columns {
      get {
        return _data[0].Length;
      }
    }
    
    IEnumerator IEnumerable.GetEnumerator() {
      return new MatrixEnumerator(_data);
    }
    
    public Matrix(int rows, int cols) {
      if ( rows <= 0 || cols <= 0 ) {
        throw new ArgumentException();
      }
      _data = new double[rows][];
      for(int i=0; i<_data.Length; ++i) {
        _data[i] = new double[cols];
      }
    }
    
    public double GetValue(int i, int j) {
      return _data[i][j];
    }
    
    public void SetValue(int i, int j, double val) {
      _data[i][j] = val;
    }
    
    // indexer
    public double this[int i, int j] {
      get {
        return _data[i][j];
      }
      set {
        _data[i][j] = value;
      }
    }
    
    public bool IsSquare {
      get {
        return Rows == Columns;
      }
    }
    
    public bool IsTriangle {
      get {
        for (int i=0; i<Rows-1; i++) {
          for (int j=0; j<Columns-i-1; j++) {
            if ( _data[i][j] != 0 ) {
              return false;
            }
          }
        }
        return true;
      }
    }
    
    public Matrix RemoveRow(int row) {
      Matrix rm = new Matrix(Rows-1, Columns);
      int k = 0;
      for (int i = 0; i < Rows; i++) {
        if ( i == row ) continue;
        for (int j=0; j<Columns; j++) {
          rm[k, j] = this[i,j];
        }
        k++;
      }
      return rm;
    }
    
    public double MeanValue {
      get {
        double sum = 0.0;
        for (int i=0; i<Rows; i++) {
          for (int j=0; j<Columns; j++) {
            sum += _data[i][j];
          }
        }
        return sum/(Rows*Columns);
      }
    }
    
    public override string ToString() {
      string infoStr = string.Format("[{0},{1}]\n", Rows, Columns);
      for (int i=0; i<Rows; ++i) {
        string rowStr = "";
        for (int j=0; j<Columns; ++j) {
          rowStr += this[i,j] + " ";
        }
        infoStr += rowStr + "\n";
      }
      return infoStr;
    }
    
    public Matrix Transpose() {
      Matrix m = new Matrix(Columns, Rows);
      for (int i=0; i<Rows; i++) {
        for (int j=0; j<Columns; j++) {
          m[j, i] = this[i, j];
        }
      }
      return m;
    }
    
    public static Matrix ReadFromConsole() {
      Matrix m;
      int rows, columns;
      rows = columns = 5;
      Console.WriteLine("Enter matrix dimensions:");
      string dimensionLine = "";
      while ((dimensionLine = Console.ReadLine()) == "") {
      }
      string[] dimsArray = dimensionLine.Split(';', ',', ' ');
      rows = Int32.Parse(dimsArray[0]);
      columns = Int32.Parse(dimsArray[1]);
      
      m = new Matrix(rows, columns);
      Console.WriteLine("Enter matrix [{0},{1}] data", rows, columns);
      for(int i=0; i<m.Rows; i++) {
        Console.Write("{0}> ", i);
        string line = Console.ReadLine();
        try {
          int j = 0;
          if (line != null) {
            string[] vars = line.Split(';', ',', ' ');
            foreach (string s in vars) {
              m[i, j++] = Double.Parse(s);
            }
          }
        }
        catch (Exception e) {
          Console.WriteLine("Error parsing line, try again");
          i--;
        }
      }

      return m;
    }
  }
}
