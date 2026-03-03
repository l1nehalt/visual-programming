using lab_3;

var matrix1 = new Matrix(3,3);
var matrix2 = new Matrix(3,3);


matrix1[0, 0] = 1;
matrix1[0, 1] = 2;
matrix1[0, 2] = 3;

matrix1[1, 0] = 2;
matrix1[1, 1] = 2;
matrix1[1, 2] = 4;

matrix2[0, 0] = 5;
matrix2[0, 1] = 2;
matrix2[0, 2] = 3;

var result1 = matrix1 - matrix2;
var result2 = matrix1 + matrix2;
var result3 = matrix1 * matrix2;

var matrix3 = new Matrix(result1);

var matrix4 = (Matrix)matrix1.Clone();

Console.WriteLine(result1[0, 0]);
Console.WriteLine(result2[0, 0]);
Console.WriteLine(result3[0, 0]);
Console.WriteLine(matrix1.ToString());
Console.WriteLine(matrix1.ToString(6));
