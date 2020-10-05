using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affine_transformation
{
    class Matrix33
    {
        double[,] matr = new double[3, 3];

        public Matrix33(double[] row1, double[] row2, double[] row3)
        {
            for (int i = 0; i < 3; i++) matr[0, i] = row1[i];
            for (int i = 0; i < 3; i++) matr[1, i] = row2[i];
            for (int i = 0; i < 3; i++) matr[2, i] = row3[i];
        }

        public Matrix33() { }

        static public Matrix33 getMatrixFromPoint(PointF point)
        {
            return new Matrix33(new double[3] { 0, 0, 0 }, new double[3] { point.X, point.Y, 1 }, new double[3] { 0, 0, 0 });
        }

        public PointF toPoint()
        {
            return new PointF((int)matr[1, 0], (int)matr[1, 1]);
        }

        public double this[int i, int j]
        {
            get { return matr[i, j]; }
            set { matr[i, j] = value; }
        }

        public static Matrix33 operator *(Matrix33 m1, Matrix33 m2)
        {
            Matrix33 res = new Matrix33();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        res[i, j] += m1[i, k] * m2[k, j];
            return res;
        }
    }
}
