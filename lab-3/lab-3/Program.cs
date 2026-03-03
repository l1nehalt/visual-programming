using lab_3;

var matrix1 = new Matrix(3,3);
var matrix2 = new Matrix(3,3);


matrix1[0, 0] = 1;
matrix1[0, 1] = 2;
matrix1[0, 2] = 3;

matrix2[0, 0] = 1;
matrix2[0, 1] = 2;
matrix2[0, 2] = 3;

var result1 = matrix1 - matrix2;
var result2 = matrix1 + matrix2;


Console.WriteLine(result1.ToString());
