using UnityEngine;
using System;
using CustomMath;
using CustomQuatern;

namespace CustomMath
{
    public struct MyMatrix4x4
    {
        public float m00;
        public float m33;
        public float m23;
        public float m13;
        public float m03;
        public float m32;
        public float m22;
        public float m02;
        public float m12;
        public float m21;
        public float m11;
        public float m01;
        public float m30;
        public float m20;
        public float m10;
        public float m31;

        public MyMatrix4x4(Vector4 col0, Vector4 col1, Vector4 col2, Vector4 col3)
        {
            m00 = col0.x; m01 = col1.x; m02 = col2.x; m03 = col3.x;

            m10 = col0.y; m11 = col1.y; m12 = col2.y; m13 = col3.y;

            m20 = col0.z; m21 = col1.z; m22 = col2.z; m23 = col3.z;

            m30 = col0.w; m31 = col1.w; m32 = col2.w; m33 = col3.w;
        }

        //
        // Resumen:
        //     Returns a matrix with all elements set to zero (Read Only).
        public static MyMatrix4x4 zero
        {
            get
            {
                Vector4 vec0 = new Vector4(0f,0f,0f,0f);
                Vector4 vec1 = new Vector4(0f,0f,0f,0f);
                Vector4 vec2 = new Vector4(0f,0f,0f,0f);
                Vector4 vec3 = new Vector4(0f,0f,0f,0f);

                return new MyMatrix4x4(vec0, vec1, vec2, vec3);
            }
        }
        //
        // Resumen:
        //     Returns the identity matrix (Read Only).
        public static MyMatrix4x4 identity
        {
            get
            {
                Vector4 vec0 = new Vector4(1f, 0f, 0f, 0f);
                Vector4 vec1 = new Vector4(0f, 1f, 0f, 0f);
                Vector4 vec2 = new Vector4(0f, 0f, 1f, 0f);
                Vector4 vec3 = new Vector4(0f, 0f, 0f, 1f);

                return new MyMatrix4x4(vec0, vec1, vec2, vec3);
            }
        }

        //
        // Resumen:
        //     Returns the transpose of this matrix (Read Only).
        public MyMatrix4x4 transpose
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        //
        // Resumen:
        //     Attempts to get a rotation quaternion from this matrix.
        public MyQuatern rotation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Resumen:
        //     Attempts to get a scale value from the matrix. (Read Only)
        public Vec3 lossyScale
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //
        // Resumen:
        //     The inverse of this matrix. (Read Only)
        public MyMatrix4x4 inverse
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        //
        // Resumen:
        //     Creates a rotation matrix.
        public static MyMatrix4x4 Rotate(MyQuatern q)
        {
            /*
            m00 = 1 - 2 * qy2 - 2 * qz2      |   m01 = 2 * qx * qy - 2 * qz * qw   |  m02 = 2 * qx * qz + 2 * qy * qw
            m10 = 2 * qx * qy + 2 * qz * qw  |   m11 = 1 - 2 * qx2 - 2 * qz2       |  m12 = 2 * qy * qz - 2 * qx * qw
            m20 = 2 * qx * qz - 2 * qy * qw  |   m21 = 2 * qy * qz + 2 * qx * qw   |  m22 = 1 - 2 * qx2 - 2 * qy2
            */

            MyMatrix4x4 newM = MyMatrix4x4.identity;

            newM.m00 = 1 - 2 * (q.y * q.y) - 2 * (q.z * q.z);
            newM.m01 = 2 * q.x * q.y - 2 * q.z * q.w;
            newM.m02 = 2 * q.x * q.z + 2 * q.y * q.w;
            newM.m10 = 2 * q.x * q.y + 2 * q.z * q.w;
            newM.m11 = 1 - 2 * (q.x * q.x) - 2 * (q.z * q.z);
            newM.m12 = 2 * q.y * q.z - 2 * q.x * q.w;
            newM.m20 = 2 * q.x * q.z - 2 * q.y * q.w;
            newM.m21 = 2 * q.y * q.z + 2 * q.x * q.w;
            newM.m22 = 1 - 2 * (q.x * q.x) - 2 * (q.y * q.y);

            return newM;
        }

        //
        // Resumen:
        //     Creates a scaling matrix.
        public static MyMatrix4x4 Scale(Vec3 vector)
        {
            MyMatrix4x4 newM = MyMatrix4x4.zero;

            newM.m00 = vector.x;
            newM.m11 = vector.y;
            newM.m22 = vector.z;
            newM.m33 = 1;

            return newM;
        }

        //
        // Resumen:
        //     Creates a translation matrix.
        public static MyMatrix4x4 Translate(Vec3 vector)
        {
            MyMatrix4x4 newM = MyMatrix4x4.identity;

            newM.m03 = vector.x;
            newM.m13 = vector.y;
            newM.m23 = vector.z;
            newM.m33 = 1;

            return newM;
        }

        // 
        // Resumen:
        //      The transposed matrix is the one that has the Matrix4x4's columns exchanged with its rows. (Read Only)
        public static MyMatrix4x4 Transpose(MyMatrix4x4 m)
        {
            return new MyMatrix4x4(new Vector4(m.m00, m.m01, m.m02, m.m03),
                                   new Vector4(m.m10, m.m11, m.m12, m.m13),
                                   new Vector4(m.m20, m.m21, m.m22, m.m23),
                                   new Vector4(m.m30, m.m31, m.m32, m.m33));
        }

        //
        // Resumen:
        //     Creates a translation, rotation and scaling matrix.
        public static MyMatrix4x4 TRS(Vec3 pos, MyQuatern q, Vec3 s)
        {
            MyMatrix4x4 translate = MyMatrix4x4.Translate(pos);
            MyMatrix4x4 rotate = MyMatrix4x4.Rotate(q);
            MyMatrix4x4 scale = MyMatrix4x4.Scale(s);

            MyMatrix4x4 newM = translate * rotate * scale;

            return newM;
        }

        public bool Equals(MyMatrix4x4 other)
        {
            return this == other;
        }

        //
        // Resumen:
        //     Returns a row of the matrix.
        public Vector4 GetRow(int index)
        {
            switch (index)
            {
                case 0:
                    return new Vector4(m00, m01, m02, m03);
                case 1:
                    return new Vector4(m10, m11, m12, m13);
                case 2:
                    return new Vector4(m20, m21, m22, m23);
                case 3:
                    return new Vector4(m30, m31, m32, m33);
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }

        //
        // Resumen:
        //     Sets a column of the matrix.
        public void SetColumn(int index, Vector4 column)
        {
            switch (index)
            {
                case 0:
                    m00 = column.x;
                    m10 = column.y;
                    m20 = column.z;
                    m30 = column.w;
                    break;
                case 1:
                    m01 = column.x;
                    m11 = column.y;
                    m21 = column.z;
                    m31 = column.w;
                    break;
                case 2:
                    m02 = column.x;
                    m12 = column.y;
                    m22 = column.z;
                    m32 = column.w;
                    break;
                case 3:
                    m03 = column.x;
                    m13 = column.y;
                    m23 = column.z;
                    m33 = column.w;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }
        //
        // Resumen:
        //     Sets a row of the matrix.
        public void SetRow(int index, Vector4 row)
        {
            switch (index)
            {
                case 0:
                    m00 = row.x;
                    m01 = row.y;
                    m02 = row.z;
                    m03 = row.w;
                    break;
                case 1:
                    m10 = row.x;
                    m11 = row.y;
                    m12 = row.z;
                    m13 = row.w;
                    break;
                case 2:
                    m20 = row.x;
                    m21 = row.y;
                    m22 = row.z;
                    m23 = row.w;
                    break;
                case 3:
                    m30 = row.x;
                    m31 = row.y;
                    m32 = row.z;
                    m33 = row.w;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid Index");
            }
        }

        //
        // Resumen:
        //     Sets this matrix to a translation, rotation and scaling matrix.
        public void SetTRS(Vec3 pos, MyQuatern q, Vec3 s)
        {
            this = MyMatrix4x4.TRS(pos, q, s);
        }

        public override string ToString()
        {
            return ("m00  " + m00 + "  m01  " + m01 + "  m02  " + m02 + "  m03  " + m03 +
                  "\nm10  " + m10 + "  m11  " + m11 + "  m12  " + m12 + "  m13  " + m13 +
                  "\nm20  " + m20 + "  m21  " + m21 + "  m22  " + m22 + "  m23  " + m23 +
                  "\nm30  " + m30 + "  m31  " + m31 + "  m32  " + m32 + "  m33  " + m33);
        }

        public static Vector4 operator *(MyMatrix4x4 lhs, Vector4 vector)
        {
            Vector4 newVec4 = Vector4.zero;

            newVec4.x = (lhs.m00 * vector.x) + (lhs.m01 * vector.x) + (lhs.m02 * vector.x) + (lhs.m03 * vector.x);

            newVec4.y = (lhs.m10 * vector.y) + (lhs.m11 * vector.y) + (lhs.m12 * vector.y) + (lhs.m13 * vector.y);

            newVec4.z = (lhs.m20 * vector.z) + (lhs.m21 * vector.z) + (lhs.m22 * vector.z) + (lhs.m23 * vector.z);

            newVec4.w = (lhs.m30 * vector.w) + (lhs.m31 * vector.w) + (lhs.m32 * vector.w) + (lhs.m33 * vector.w);

            return newVec4;
        }

        public static MyMatrix4x4 operator *(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            // Primero los elementos de las filas (lhs) y despues los elementos de las columnas (rhs)
            MyMatrix4x4 newMatrix = MyMatrix4x4.zero;

            newMatrix.m00 = (lhs.m00 * rhs.m00) + (lhs.m01 * rhs.m10) + (lhs.m02 * rhs.m20) + (lhs.m03 * rhs.m30);
            newMatrix.m01 = (lhs.m00 * rhs.m01) + (lhs.m01 * rhs.m11) + (lhs.m02 * rhs.m21) + (lhs.m03 * rhs.m31);
            newMatrix.m02 = (lhs.m00 * rhs.m02) + (lhs.m01 * rhs.m12) + (lhs.m02 * rhs.m22) + (lhs.m03 * rhs.m32);
            newMatrix.m03 = (lhs.m00 * rhs.m03) + (lhs.m01 * rhs.m13) + (lhs.m02 * rhs.m23) + (lhs.m03 * rhs.m33);

            newMatrix.m10 = (lhs.m10 * rhs.m00) + (lhs.m11 * rhs.m10) + (lhs.m12 * rhs.m20) + (lhs.m13 * rhs.m30);
            newMatrix.m11 = (lhs.m10 * rhs.m01) + (lhs.m11 * rhs.m11) + (lhs.m12 * rhs.m21) + (lhs.m13 * rhs.m31);
            newMatrix.m12 = (lhs.m10 * rhs.m02) + (lhs.m11 * rhs.m12) + (lhs.m12 * rhs.m22) + (lhs.m13 * rhs.m32);
            newMatrix.m13 = (lhs.m10 * rhs.m03) + (lhs.m11 * rhs.m13) + (lhs.m12 * rhs.m23) + (lhs.m13 * rhs.m33);

            newMatrix.m20 = (lhs.m20 * rhs.m00) + (lhs.m21 * rhs.m10) + (lhs.m22 * rhs.m20) + (lhs.m23 * rhs.m30);
            newMatrix.m21 = (lhs.m20 * rhs.m01) + (lhs.m21 * rhs.m11) + (lhs.m22 * rhs.m21) + (lhs.m23 * rhs.m31);
            newMatrix.m22 = (lhs.m20 * rhs.m02) + (lhs.m21 * rhs.m12) + (lhs.m22 * rhs.m22) + (lhs.m23 * rhs.m32);
            newMatrix.m23 = (lhs.m20 * rhs.m03) + (lhs.m21 * rhs.m13) + (lhs.m22 * rhs.m23) + (lhs.m23 * rhs.m33);

            newMatrix.m30 = (lhs.m30 * rhs.m00) + (lhs.m31 * rhs.m10) + (lhs.m32 * rhs.m20) + (lhs.m33 * rhs.m30);
            newMatrix.m31 = (lhs.m30 * rhs.m01) + (lhs.m31 * rhs.m11) + (lhs.m32 * rhs.m21) + (lhs.m33 * rhs.m31);
            newMatrix.m32 = (lhs.m30 * rhs.m02) + (lhs.m31 * rhs.m12) + (lhs.m32 * rhs.m22) + (lhs.m33 * rhs.m32);
            newMatrix.m33 = (lhs.m30 * rhs.m03) + (lhs.m31 * rhs.m13) + (lhs.m32 * rhs.m23) + (lhs.m33 * rhs.m33);

            return newMatrix;
        }
        public static bool operator ==(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            return (lhs.m00 == rhs.m00 && lhs.m01 == rhs.m01 && lhs.m02 == rhs.m02 && lhs.m03 == rhs.m03 &&
                    lhs.m10 == rhs.m10 && lhs.m11 == rhs.m11 && lhs.m12 == rhs.m12 && lhs.m13 == rhs.m13 &&
                    lhs.m20 == rhs.m20 && lhs.m21 == rhs.m21 && lhs.m22 == rhs.m22 && lhs.m23 == rhs.m23 &&
                    lhs.m30 == rhs.m30 && lhs.m31 == rhs.m31 && lhs.m32 == rhs.m32 && lhs.m33 == rhs.m33 );
        }
        public static bool operator !=(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
        {
            return !(lhs == rhs);
        }
    }
}
