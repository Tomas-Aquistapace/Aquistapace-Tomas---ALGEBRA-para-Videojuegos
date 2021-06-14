using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CustomMath
{
    public struct MyMatrix4x4 : IEquatable<MyMatrix4x4>
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

        public float this[int index] { get; set; }
        public float this[int row, int column] { get; set; }

        //
        // Resumen:
        //     Returns a matrix with all elements set to zero (Read Only).
        public static Matrix4x4 zero { get; }
        //
        // Resumen:
        //     Returns the identity matrix (Read Only).
        public static Matrix4x4 identity { get; }


        //
        // Resumen:
        //     Returns the transpose of this matrix (Read Only).
        public Matrix4x4 transpose { get; }
        //
        // Resumen:
        //     Attempts to get a rotation quaternion from this matrix.
        public Quaternion rotation { get; }
        //
        // Resumen:
        //     Attempts to get a scale value from the matrix. (Read Only)
        public Vector3 lossyScale { get; }


        //
        // Resumen:
        //     The inverse of this matrix. (Read Only)
        public Matrix4x4 inverse { get; }



        //
        // Resumen:
        //     Creates a rotation matrix.
        //
        // Parámetros:
        //   q:
        public static Matrix4x4 Rotate(Quaternion q)
        {

        }

        //
        // Resumen:
        //     Creates a scaling matrix.
        //
        // Parámetros:
        //   vector:
        public static Matrix4x4 Scale(Vector3 vector)
        {

        }

        //
        // Resumen:
        //     Creates a translation matrix.
        //
        // Parámetros:
        //   vector:
        public static Matrix4x4 Translate(Vector3 vector)
        {

        }

        public static Matrix4x4 Transpose(Matrix4x4 m)
        {

        }

        //
        // Resumen:
        //     Creates a translation, rotation and scaling matrix.
        //
        // Parámetros:
        //   pos:
        //
        //   q:
        //
        //   s:
        public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s)
        {

        }



        public bool Equals(Matrix4x4 other)
        {

        }



        //
        // Resumen:
        //     Returns a row of the matrix.
        //
        // Parámetros:
        //   index:
        public Vector4 GetRow(int index)
        {

        }


        //
        // Resumen:
        //     Sets a column of the matrix.
        //
        // Parámetros:
        //   index:
        //
        //   column:
        public void SetColumn(int index, Vector4 column)
        {

        }
        //
        // Resumen:
        //     Sets a row of the matrix.
        //
        // Parámetros:
        //   index:
        //
        //   row:
        public void SetRow(int index, Vector4 row)
        {

        }
        //
        // Resumen:
        //     Sets this matrix to a translation, rotation and scaling matrix.
        //
        // Parámetros:
        //   pos:
        //
        //   q:
        //
        //   s:
        public void SetTRS(Vector3 pos, Quaternion q, Vector3 s)
        {

        }



        public static Vector4 operator *(Matrix4x4 lhs, Vector4 vector)
        {

        }
        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {

        }
        public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs)
        {

        }
        public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            
        }
    }
}
