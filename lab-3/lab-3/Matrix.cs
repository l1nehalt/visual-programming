namespace lab_3;

public class Matrix : ICloneable
{
    private readonly double[,] _elements;

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
        for (uint j = 0; j < Columns; j++)
            _elements[i, j] = matrix[i, j];
    }

    public uint Rows { get; }
    public uint Columns { get; }

    public double this[uint row, uint column]
    {
        get => _elements[row, column];
        set => _elements[row, column] = value;
    }

    public object Clone()
    {
        var clonedMatrix = new Matrix(Rows, Columns);

        for (uint i = 0; i < Rows; i++)
        for (uint j = 0; j < Columns; j++)
            clonedMatrix[i, j] = this[i, j];

        return clonedMatrix;
    }

    public override string ToString()
    {
        return $"Кол-во строк: {Rows}, Кол-во столбцов: {Columns}, Всего элементов: {Rows * Columns}";
    }

    public string ToString(uint n)
    {
        var elements = new List<string>();
        elements.Add($"Первые {n} элементов матрицы {Rows}x{Columns}:");

        uint count = 0;

        for (uint i = 0; i < Rows && count < n; i++)
        for (uint j = 0; j < Columns && count < n; j++)
        {
            elements.Add($"[{i},{j}] = {_elements[i, j]}");
            count++;
        }

        return string.Join("\n", elements);
    }

    public static Matrix operator +(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Rows, left.Columns);

        for (uint i = 0; i < left.Rows; i++)
        for (uint j = 0; j < left.Columns; j++)
            result[i, j] = left[i, j] + right[i, j];

        return result;
    }

    public static Matrix operator -(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Rows, left.Columns);

        for (uint i = 0; i < left.Rows; i++)
        for (uint j = 0; j < left.Columns; j++)
            result[i, j] = left[i, j] - right[i, j];

        return result;
    }

    public static Matrix operator *(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Rows, right.Columns);

        for (uint i = 0; i < left.Rows; i++)
        for (uint j = 0; j < right.Columns; j++)
        {
            double sum = 0;
            for (uint k = 0; k < left.Columns; k++) sum += left[i, k] * right[k, j];
            result[i, j] = sum;
        }

        return result;
    }
}