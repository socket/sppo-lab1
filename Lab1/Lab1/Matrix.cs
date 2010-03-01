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
        for (int i=0; i<Rows; i++) {
          for (int j=0; j<Columns-i; j++) {
            if ( _data[i][j] != 0 ) {
              return false;
            }
          }
        }
        return true;
      }
    }
    
    public void RemoveColumn(int column) {
      if ( column < 0 || column > _data[0].Length ) {
        throw new IndexOutOfRangeException();
      }
      for (int k=0; k<_data.Length; k++) {
        double[] d = _data[k];
        var newRow = new double[Columns - 1];
        int col = 0;
        for (int i = 0; i < Columns; i++) {
          if (col != column) {
            newRow[col] = d[i];
            col++;
          }
        }
        _data[k] = newRow;
      }
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
  }
}
