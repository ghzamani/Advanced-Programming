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
    }
}