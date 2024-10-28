namespace _28._10._24
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Matrix mat1 = new Matrix(3, 3);  // Создаём 3x3 матрицу со случайными значениями
            Matrix mat2 = new Matrix(3, 3);  // Ещё одна 3x3 матрица со случайными значениями

            Console.WriteLine("matrix 1:");
            Console.WriteLine(mat1);

            Console.WriteLine("matrix 2:");
            Console.WriteLine(mat2);

            Matrix sum = mat1 + mat2;
            Console.WriteLine("Sum:");
            Console.WriteLine(sum);

            Matrix result = mat1 * 2;
            Console.WriteLine("matrix 1 * 2:");
            Console.WriteLine(result);

            result = mat1 * mat2;
            Console.WriteLine("matrix 1 * matrix 2:");
            Console.WriteLine(result);

            Console.WriteLine("max matrix 1: " + mat1.Max());
            Console.WriteLine("min matrix 2: " + mat2.Min());

            Console.WriteLine("Equal check " + (mat1 == mat2));

        }

        public class Matrix
        {
            private int[,] mat;
            private static Random _random = new Random();

            public Matrix(int rows, int columns, int minValue = 0, int maxValue = 10)
            {
                mat = new int[rows, columns];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                        mat[i, j] = _random.Next(minValue, maxValue);
            }

            public int Rows => mat.GetLength(0);
            public int Columns => mat.GetLength(1);

            public int this[int i, int j]
            {
                get { return mat[i, j]; }
                set { mat[i, j] = value; }
            }
            #region MinMax
            public int Max()
            {
                int max = mat[0, 0];
                foreach (int value in mat)
                    if (value > max) max = value;
                return max;
            }

            public int Min()
            {
                int min = mat[0, 0];
                foreach (int value in mat)
                    if (value < min) min = value;
                return min;
            }
#endregion

            #region Перегрузки
            public static Matrix operator +(Matrix a, Matrix b)
            {
                if (a.Rows != b.Rows || a.Columns != b.Columns)
                    throw new InvalidOperationException("matrixes must be of the same size.");

                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Columns; j++)
                        result[i, j] = a[i, j] + b[i, j];
                return result;
            }

            public static Matrix operator -(Matrix a, Matrix b)
            {
                if (a.Rows != b.Rows || a.Columns != b.Columns)
                    throw new InvalidOperationException("matrixes must be of the same size.");

                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Columns; j++)
                        result[i, j] = a[i, j] - b[i, j];
                return result;
            }

            public static Matrix operator *(Matrix a, Matrix b)
            {
                if (a.Columns != b.Rows)
                    throw new InvalidOperationException("the number of columns of the first matrix must match the number of rows of the second matrix.");

                Matrix result = new Matrix(a.Rows, b.Columns);
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < b.Columns; j++)
                        for (int k = 0; k < a.Columns; k++)
                            result[i, j] += a[i, k] * b[k, j];
                return result;
            }

            public static Matrix operator *(Matrix a, int b)
            {
                Matrix result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                    for (int j = 0; j < a.Columns; j++)
                        result[i, j] = a[i, j] * b;
                return result;
            }

            public static bool operator ==(Matrix a, Matrix b)
            {
                if (ReferenceEquals(a, b))  return true;
                if (a is null || b is null) return false;
                return a.Equals(b); 
            }

            public static bool operator !=(Matrix a, Matrix b) => !(a == b);

            public override bool Equals(object obj)
            {
                if (obj == null || obj.GetType() != typeof(Matrix))
                    return false;

                Matrix other = (Matrix)obj;

                if (Rows != other.Rows || Columns != other.Columns)
                    return false;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    { 
                        if (this[i, j] != other[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public override string ToString()
            {
                string result = "";
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                        result += mat[i, j] + "\t";
                    result += "\n";
                }
                return result;
            }
        }
        #endregion
    }
}

