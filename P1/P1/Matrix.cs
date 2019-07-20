using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> : 
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            this.Rows = new Vector<_Type>[rowCount];
            for(int i=0; i<Rows.Length;i++)
            {
                Rows[i] = new Vector<_Type>(columnCount);
            }
        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
            :this(rows.Count(),rows.ToArray()[0].Size)
        {
            this.Rows = rows.ToArray();
        }

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public Vector<_Type> this[int index]
        {
            get
            {
                return Rows[index];
            }
            set
            {
                Rows[index] = value;
            }
        }

        public _Type this[int row, int col]
        {
            get
            {
                return Rows[row][col];
            }
            set
            {
                Rows[row][col] = value;
            }
        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (!(m1.RowCount == m2.RowCount && m1.ColumnCount == m2.ColumnCount))
                throw new InvalidOperationException("RowsCount or ColumnsCount weren't the same" +
                    ", so '+' is invalid" );

            Matrix <_Type> sum = new Matrix<_Type>(m1.RowCount, m1.ColumnCount);
            for (int i = 0; i < sum.RowCount; i++)
                sum[i] = m1[i] + m2[i];
        
            return sum;
        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.ColumnCount != m2.RowCount)
                throw new InvalidOperationException("First matrix ColumnCount is not the same as" +
                    " Second matrix RowCount , so '*' is invalid");

            Matrix <_Type> m2columnsvectors = new Matrix<_Type>(m2.ColumnCount,m2.RowCount);
            for(int i=0; i < m2.ColumnCount; i++)
            {
                m2columnsvectors[i] = m2.GetColumn(i);
            }

            Matrix<_Type> multiply = new Matrix<_Type>(m1.RowCount,m2.ColumnCount);
            for (int i = 0; i < multiply.RowCount; i++)
            {
                for (int j = 0; j < multiply.ColumnCount; j++)
                {
                    multiply[i][j] = m1[i] * m2columnsvectors[j];
                }
            }

            return multiply;
        }

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            for (int i = 0; i < RowCount; i++)
                yield return Rows[i][col];
        } 

        public Vector<_Type> GetColumn(int col) => 
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            if (!(other.RowCount == this.RowCount &&
                other.ColumnCount == this.ColumnCount))
                return false;

            for (int i = 0; i < RowCount; i++)
            {
                if (Rows[i] != other[i])
                    return false;
            } 
            return true;
        }

        public override string ToString()
        {
            string matrix = "[" + "\n";
            int idx = 0;
            foreach (var row in Rows)
            {
                matrix = matrix + row.ToString();
                if (idx != Rows.Length - 1)
                    matrix += ',';
                matrix += "\n";
                idx++;
            }
            matrix += ']';

            return matrix;
        }

        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
            => m1.Equals(m2);

        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2)
            => ! m1.Equals(m2);

        public override bool Equals(object obj)
        {
            Matrix<_Type> matrix = obj as Matrix<_Type>;
            return this == matrix;
        }
        
        public override int GetHashCode()
        {
            int code = 0;
            foreach(var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        //public static Matrix<_Type> Transpose(Matrix<_Type> m)
        //{
        //    Matrix<_Type> result = new Matrix<_Type>(m.ColumnCount, m.RowCount);
        //    for (int i = 0; i < m.ColumnCount; i++)
        //    {
        //        result[i] = m.GetColumn(i);
        //    }
        //    return result;
        //}
        //couldn't call it!

        

    }
}