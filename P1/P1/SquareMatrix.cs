using System;
using System.Collections.Generic;
using System.IO;

namespace A10
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(IEnumerable<Vector<_Type>> rows)
            : base(rows)
        {
        }

        public SquareMatrix(int rowCount) 
            : base(rowCount, rowCount)
        {
        }

        public SquareMatrix(int rowCount, int colCount)
            :base(rowCount,colCount)
        {
            if (rowCount != colCount)
                throw new InvalidDataException("This isn't a SqaureMatrix");
        }

        public double Determinant (SquareMatrix<double> m )
        {
            int order = m.RowCount;
            double det = 0;
            if (order == 1)
                return m[0][0];
            if (order == 2)
                return m[0][0] * m[1][1] - m[0][1] * m[1][0];
            if(order > 2)
            {                
                for(int i = 0; i < order; i++)
                {
                    det += m[0][i] * Determinant(PartOfMatrix(m,0,i)) * Math.Pow(-1,i);
                }                
            }
            return det;
        }

        public SquareMatrix<double> Transpose(SquareMatrix<double> m)
        {
            SquareMatrix<double> result = new SquareMatrix<double>(m.ColumnCount, m.RowCount);
            for (int i = 0; i < m.ColumnCount; i++)
            {
                result[i] = m.GetColumn(i);
            }
            return result;
        }

        // ماتریس الحاقی بعد از اعمال علامت
        public SquareMatrix<double> CofactorMatrix(SquareMatrix<double> m)
        {
            SquareMatrix<double> result = new SquareMatrix<double>(m.RowCount);

            for(int i = 0; i < m.RowCount; i++)
            {
                for(int j = 0; j < m.RowCount; j++)
                {
                    result[i][j] = Math.Pow(-1, i + j) * Determinant(PartOfMatrix(m, i, j));
                }
            }
            return result;
        }

        public SquareMatrix<double> PartOfMatrix(SquareMatrix<double> m , int i , int j)
        {
            //List<Vector<double>> vectors = new List<Vector<double>>();
            Vector<double> vector;
            SquareMatrix<double> result = new SquareMatrix<double>(m.RowCount-1);

            //برای پیدا کردن سطر و ستونی که شامل 
            //i , j نیست
            List<int> rowIndexWithouti = new List<int>();
            List<int> rowIndexWithoutj = new List<int>();
            for (int a = 0; a < m.RowCount; a++)
            {
                if (a != i)
                    rowIndexWithouti.Add(a);                   
                
                if(a != j)
                    rowIndexWithoutj.Add(a);
            }

            int x = 0;
            foreach(var v in rowIndexWithouti)
            {
                vector = new Vector<double>(m.RowCount - 1);
                foreach(var w in rowIndexWithoutj)
                {
                    vector.Add(m[v][w]);                    
                }
                //vectors.Add(vector);
                result[x] = vector;
                x++;
            }

            //for(int s = 0; s < vectors.Count; s++)
            //{
            //    result[s] = vectors[s];
            //}

            return result;
        }


        public SquareMatrix<double> InverseMatrix(SquareMatrix<double> m)
        {
            SquareMatrix<double> result = new SquareMatrix<double>(m.RowCount);
            for(int i = 0; i < m.RowCount; i++)
            {
                for(int j = 0; j < m.RowCount; j++)
                {
                    if (Determinant(m) == 0)
                        throw new InvalidOperationException("You can't inverse this matrix.");

                    result[i][j] = (1 / Determinant(m)) * Transpose(CofactorMatrix(m))[i][j];
                }
            }
            return result;
        }

        public static bool CheckConsistent(SquareMatrix<double> m , Matrix<double> m2)
        {
            for(int i = 0; i < m.RowCount; i++)
            {
                for (int j = 0; j != i && j < m.RowCount; j++)  
                {
                    if (Vector<double>.MultipledVectors(m[i], m[j]))
                    {
                        if (Vector<double>.d != m2[i][0] / m2[j][0])
                            return false;
                    }
                }
            }
         
            return true;
        }

       
    }
}