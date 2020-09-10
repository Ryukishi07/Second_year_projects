using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_41_Matrix_Algebra
{

	public class Class_Matrix
	{
		public static void Read_Matrix_A(string path, out double[,] A, out int n)
		{
			FileInfo fi = new FileInfo(path);
			if (fi.Extension == ".txt")
			{
				bool dot_or_comma;
				try
				{
					double dot = Convert.ToDouble("0.1");
					dot_or_comma = true;
				}
				catch (FormatException) { dot_or_comma = false; }
				StreamReader rdr = new StreamReader(fi.OpenRead());
				n = Convert.ToInt32(rdr.ReadLine());
				A = new double[n, n];
				string[] numbers; string line;
				for (int i = 0; i < n; i++)
				{
					line = (rdr.ReadLine()).Trim();
					if (dot_or_comma) line = line.Replace(",", ".");
					else line = line.Replace(".", ",");
					numbers = line.Split(new char[] { ' ', ';' },
										 StringSplitOptions.RemoveEmptyEntries);
					for (int j = 0; j < n; j++)
						A[i, j] = Convert.ToDouble(numbers[j]);
				}
				rdr.Close(); return;
			}
			if (fi.Extension == ".bin")
			{
				BinaryReader rdr = new BinaryReader(fi.OpenRead());
				n = rdr.ReadInt32();
				A = new double[n, n];
				for (int i = 0; i < n; i++)
					for (int j = 0; j < n; j++)
						A[i, j] = rdr.ReadDouble();
				rdr.Close(); return;
			}
			A = null; n = 0;
		}

		public static string Print_A(double[,] A, bool form, int fs, int fd, string title)
		{
			int ka, n = A.GetLength(0); string txt = "\r\n", frmt;
			if (title != "")
				txt += " " + title + String.Format(" size = {0}\r\n", n);
			if (form)
			{
				frmt = "{0:F" + string.Format("{0}", fd) + "}";
				int max_ka = 0; double a;
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						a = Math.Abs(A[i, j]);
						if (a < 10.0) ka = 1; else ka = (int)Math.Ceiling(Math.Log10(a));
						max_ka = Math.Max(max_ka, ka);
					}
				}
				ka = fs + 1 + max_ka + 1 + fd;
			}
			else
			{
				frmt = "{0:E" + string.Format("{0}", fd) + "}";
				ka = fs + 1 + 1 + 1 + fd + 1 + 1 + 3;
			}
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
					txt += string.Format(frmt, A[i, j]).PadLeft(ka);
				txt += "\r\n";
			}
			return txt;
		}

		public static void Identity_Matrix(int N, out double[,] E)
		{
			E = new double[N, N];
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
					E[i, j] = 0.0;
				E[i, i] = 1.0;
			}
		}

		public static void Test_Matrix(int N, out double[,] T)
		{
			T = new double[N, N];
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					T[i, j] = 10.0 * (i + 1.0) + j + 1.0;
		}

		public static void Transpose_Matrix(double[,] A)
		{
			int i, j, N = A.GetLength(0); double aij;
			for (i = 0; i < N; i++)
			{
				for (j = 0; j < N; j++)
				{
					aij = A[i, j];
					A[i, j] = A[j, i];
					A[j, i] = aij;
				}
			}
		}

		public static void Transpose_Matrix(double[,] A, out double[,] AT)
		{
			int i, j, N = A.GetLength(0);
			AT = new double[N, N];
			for (i = 0; i < N; i++)
				for (j = 0; j < N; j++)
					AT[i, j] = A[j, i];
		}

		public static void Copy_Matrix(double[,] A, out double[,] C)
		{
			int i, j, N = A.GetLength(0);
			C = new double[N, N];
			for (i = 0; i < N; i++)
				for (j = 0; j < N; j++)
					C[i, j] = A[i, j];
		}

		public static void U_Matrix(int N, out double[,] U)
		{
			U = new double[N, N];
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					U[i, j] = (j - i) + 1.0;
		}

		public static void Matrix_Rotation(double[,] A, out double[,] AR, bool key)
		{
			int i, j, N = A.GetLength(0); AR = new double[N, N];
			if (key)
				for (j = 0; j < N; j++)
					for (i = 0; i < N; i++)
						AR[N - 1 - j, i] = A[i, j];
			else
				for (i = 0; i < N; i++)
					for (j = 0; j < N; j++)
						AR[j, N - 1 - i] = A[i, j];
		}

		public static void Matrix_Rotation(double[,] A, bool key)
		{
			int i, j, N = A.GetLength(0); double[,] AR = new double[N, N];
			if (key)
				for (j = 0; j < N; j++)
					for (i = 0; i < N; i++)
						AR[N - 1 - j, i] = A[i, j];
			else
				for (i = 0; i < N; i++)
					for (j = 0; j < N; j++)
						AR[j, N - 1 - i] = A[i, j];
			for (i = 0; i < N; i++)
				for (j = 0; j < N; j++)
					A[i, j] = AR[i, j];
		}

		public static void Sum(double[,] A, double[,] B, out double[,] C)
		{
			int i, j, n = A.GetLength(0); C = new double[n, n];
			for (i = 0; i < n; i++)
				for (j = 0; j < n; j++)
					C[i, j] = A[i, j] + B[i, j];
		}

		public static void Sub(double[,] A, double[,] B, out double[,] C)
		{
			int i, j, n = A.GetLength(0); C = new double[n, n];
			for (i = 0; i < n; i++)
				for (j = 0; j < n; j++)
					C[i, j] = A[i, j] - B[i, j];
		}

		public static void Mult(double[,] A, double k, out double[,] C)
		{
			int i, j, n = A.GetLength(0); C = new double[n, n];
			for (i = 0; i < n; i++)
				for (j = 0; j < n; j++)
					C[i, j] = k * A[i, j];
		}

		public static void Matrix_mult(double[,] A, double[,] B, out double[,] C)
		{
			int i, j, n = A.GetLength(0); C = new double[n, n];
			for (i = 0; i < n; i++)
			{
				for (j = 0; j < n; j++)
				{
					C[i, j] = 0;
					for (int k = 0; k < n; k++)
					{
						C[i, j] += A[i, k] * B[k, j];
					}
				}
			}
		}

		public static void LU_Factorization(double[,] A, out double[,] L,
									 out double[,] U, out double det)
		{
			int n = A.GetLength(0);
			L = new double[n, n]; U = new double[n, n];
			for (int j = 0; j < n; j++)
				U[0, j] = A[0, j];
			det = U[0, 0];
			for (int i = 0; i < n; i++)
				L[i, 0] = A[i, 0] / A[0, 0];
			double s; int m, k;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					m = Math.Min(i, j) - 1; s = A[i, j];
					for (k = 0; k <= m; k++)
						s -= L[i, k] * U[k, j];
					if (i > j)
						L[i, j] = s / U[j, j];
					else U[i, j] = s;
				}
				L[i, i] = 1.0; det *= U[i, i];
			}
		}

		public static void Minor_1(double[,] A, int I, int J, out double[,] M)
		{
			int i_A, j_A, i_M, j_M, n = (A.GetLength(0) - 1);
			M = new double[n, n];
			i_M = 0;
			for (i_A = 0; i_A <= n; i_A++)
			{
				if (i_A == I) continue;
				j_M = 0;
				for (j_A = 0; j_A <= n; j_A++)
				{
					if (j_A == J) continue;
					M[i_M, j_M] = A[i_A, j_A];
					j_M++;
				}
				i_M++;
			}
		}

		public static double Determinant_JO_JO(double[,] A)
		{
			int n = (int)A.GetLength(0);
			if (n == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
			int k, znak = -1; double det = 0.0; double[,] M;
			for (k = 0; k < n; k++)
			{
				znak = -znak; Minor_1(A, k, 0, out M);
				det += znak * A[k, 0] * Determinant_JO_JO(M);
			}
			return det;
		}

		public static double Cofactor(double[,] A, int I, int J)
		{
			if (A.GetLength(0) == 2)
			{
				if (I == J) return A[0, 0] * A[1, 1];
				else return -A[0, 0] * A[1, 0];
			}
			double[,] minor;
			Minor_1(A, I, J, out minor);
			double A_IJ = Determinant_JO_JO(minor);
			if ((I + J) % 2 == 0) return A_IJ; else return -A_IJ;
		}

		public static double Determinant(double[,] A, int K, bool flag)
		{
			int n = (int)A.GetLength(0);
			if (n == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
			double determinant = 0.0;
			if (flag)
			{
				for (int j = 0; j < n; j++)
					determinant += A[K, j] * Cofactor(A, K, j);
			}
			else
			{
				for (int i = 0; i < n; i++)
					determinant += A[i, K] * Cofactor(A, i, K);
			}
			return determinant;
		}

	}

	class MainClass
	{

		static int N;
		static double[,] A, B, C, D;
		static string title, file1, file2;
		static StreamWriter SW;

		static void Test_of_Read_and_Print_Matrix()
		{
			file1 = "Test1.txt";
			title = " ";
			Class_Matrix.Read_Matrix_A(file1, out A, out N);
			string txt = Class_Matrix.Print_A(A, true, 1, 2, title);
			Console.Write(txt);
		}

		static void Test_of_Generation_of_Matrix()
		{
			Class_Matrix.Test_Matrix(5, out D);
            string txt = Class_Matrix.Print_A(D, true, 1, 2, title);
            Console.Write(txt);
		}

		static void Test_of_rotation_of_Matrix()
		{
			Class_Matrix.Matrix_Rotation(A, true);
            string txt = Class_Matrix.Print_A(A, true, 1, 2, title);
            Console.Write(txt);
		}

		static void Test_of_Sum_and_Sub_of_Matrix()
		{
			file1 = "Test1.txt";
			file2 = "Test2.txt";
			Class_Matrix.Read_Matrix_A(file1, out A, out N);
			Class_Matrix.Read_Matrix_A(file2, out B, out N);
			Class_Matrix.Sum(A, B, out C);
			SW.WriteLine(Class_Matrix.Print_A(C, true, 1, 2, title));
            string txt_1 = Class_Matrix.Print_A(C, true, 1, 2, title);
            Console.Write(txt_1);
			Class_Matrix.Sub(A, B, out C);
            string txt_2 = Class_Matrix.Print_A(C, true, 1, 2, title);
            Console.Write(txt_2);
		}

		static void Test_of_Mult_of_Matrix()
		{
			file1 = "Test1.txt";
			file2 = "Test2.txt";
			Class_Matrix.Read_Matrix_A(file1, out A, out N);
			Class_Matrix.Read_Matrix_A(file2, out B, out N);
			Class_Matrix.Matrix_mult(A, B, out C);
            string txt = Class_Matrix.Print_A(C, true, 1, 2, title);
            Console.Write(txt);
		}

		public static void Main(string[] args)
		{
			SW = new StreamWriter("Result.txt");
			Test_of_Read_and_Print_Matrix();
			Test_of_Generation_of_Matrix();
			Test_of_rotation_of_Matrix();
			Test_of_Sum_and_Sub_of_Matrix();
			Test_of_Mult_of_Matrix();
			SW.Close();
			Console.ReadLine();
		}
	}
}

