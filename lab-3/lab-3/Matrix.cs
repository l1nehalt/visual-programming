using System.Text;

namespace lab_3;

public class Matrix : ICloneable
{
    public uint Rows { get; }
    public uint Columns { get; }
    
    private double[,] _elements;
    
    public Matrix(uint rows, uint columns)
    {
        Rows = rows;
        Columns = columns;
        _elements = new double[rows, columns];
    }
    
    public Matrix(Matrix matrix)
    {
        Rows = matrix.Rows;
        Columns = matrix.Columns;
        _elements = new double[Rows, Columns];
        
        for (uint i = 0; i < Rows; i++)
        {
            for (uint j = 0; j < Columns; j++)
            {
                _elements[i, j] = matrix[i, j];
            }
        }
    }
    
    public double this[uint row, uint column]
    {
        get => _elements[row, column];
        set => _elements[row, column] = value;
    }
    
    public override string ToString()
    {
        return $"Кол-во строк: {Rows}, Кол-во столбцов: {Columns}, Всего элементов: {Rows * Columns}";
    }

    public object Clone()
    {
        Matrix clonedMatrix = new Matrix(Rows, Columns);
        
        for (uint i = 0; i < Rows; i++)
        {
            for (uint j = 0; j < Columns; j++)
            {
                clonedMatrix[i, j] = this[i, j];
            }
        }
        
        return clonedMatrix;
    }

    public string ToString(uint n)
    {
        uint totalElements = Rows * Columns;
        uint elementsToShow = Math.Min(n, totalElements);
        
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Первые {elementsToShow} элементов матрицы {Rows}x{Columns}:");
        
        uint count = 0;
        
        for (uint i = 0; i < Rows && count < elementsToShow; i++)
        {
            for (uint j = 0; j < Columns && count < elementsToShow; j++)
            {
                sb.AppendLine($"[{i},{j}] = {_elements[i, j]}");
                count++;
            }
        }
        
        return sb.ToString();
    }
    
    public static Matrix operator +(Matrix left, Matrix right)
    {
        Matrix result = new Matrix(left.Rows, left.Columns);
        
        for (uint i = 0; i < left.Rows; i++)
        {
            for (uint j = 0; j < left.Columns; j++)
            {
                result[i, j] = left[i, j] + right[i, j];
            }
        }
        
        return result;
    }

    public static Matrix operator -(Matrix left, Matrix right)
    {
        Matrix result = new Matrix(left.Rows, left.Columns);
        
        for (uint i = 0; i < left.Rows; i++)
        {
            for (uint j = 0; j < left.Columns; j++)
            {
                result[i, j] = left[i, j] - right[i, j];
            }
        }
        
        return result;
    }
    
    public static Matrix operator *(Matrix left, Matrix right)
    {
        
        Matrix result = new Matrix(left.Rows, right.Columns);
        
        for (uint i = 0; i < left.Rows; i++)
        {
            for (uint j = 0; j < right.Columns; j++)
            {
                double sum = 0;
                for (uint k = 0; k < left.Columns; k++)
                {
                    sum += left[i, k] * right[k, j];
                }
                result[i, j] = sum;
            }
        }
        
        return result;
    }
}