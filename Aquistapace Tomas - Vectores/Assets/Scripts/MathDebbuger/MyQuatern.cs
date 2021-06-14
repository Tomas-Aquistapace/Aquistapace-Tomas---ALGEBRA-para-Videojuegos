using System.Reflection;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngine;
using System;
using CustomMath;

namespace CustomQuatern
{
    public struct MyQuatern : IEquatable<MyQuatern>
    {
        #region Variables
        public const float kEpsilon = 1E-06F;
        public float _x;
        public float _y;
        public float _z;
        public float _w;

        public MyQuatern(float x, float y, float z, float w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }

        //public float this[int index] { get; set; }
        public static MyQuatern identity { get; }
        public Vec3 eulerAngles { get; set; }
        public Quaternion normalized { get; }
        #endregion

        #region Public Methods
        //
        // Resumen:
        //     Returns the angle in degrees between two rotations a and b.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        public static float Angle(MyQuatern a, MyQuatern b)
        {


            return 0f;
        }
        //
        // Resumen:
        //     Creates a rotation which rotates angle degrees around axis.
        //
        // Parámetros:
        //   angle:
        //
        //   axis:
        public static MyQuatern AngleAxis(float angle, Vector3 axis)
        {

        }
        public static MyQuatern AxisAngle(Vector3 axis, float angle)
        {

        }
        //
        // Resumen:
        //     The dot product between two rotations.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        public static float Dot(MyQuatern a, MyQuatern b)
        {

            return 0f;
        }
        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
        //
        // Parámetros:
        //   euler:
        public static MyQuatern Euler(Vec3 euler)
        {
            MyQuatern qz;
            MyQuatern qx;
            MyQuatern qy;

            float sinAngleX = Mathf.Sin(Mathf.Deg2Rad * euler.x * 0.5f);
            float cosAngleX = Mathf.Cos(Mathf.Deg2Rad * euler.x * 0.5f);
            qx.Set(sinAngleX, 0, 0, cosAngleX);

            float sinAngleY = Mathf.Sin(Mathf.Deg2Rad * euler.y * 0.5f);
            float cosAngleY = Mathf.Cos(Mathf.Deg2Rad * euler.y * 0.5f);
            qy.Set(0, sinAngleY, 0, cosAngleY);

            float sinAngleZ = Mathf.Sin(Mathf.Deg2Rad * euler.z * 0.5f);
            float cosAngleZ = Mathf.Cos(Mathf.Deg2Rad * euler.z * 0.5f);
            qz.Set(0, 0, sinAngleZ, cosAngleZ);

            return (qx * qy * qz);
        }
        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis; applied in that order.
        //
        // Parámetros:
        //   x:
        //
        //   y:
        //
        //   z:
        public static MyQuatern Euler(float x, float y, float z)
        {

        }
        public static MyQuatern EulerAngles(float x, float y, float z)
        {

        }
        public static MyQuatern EulerAngles(Vec3 euler)
        {

        }
        public static MyQuatern EulerRotation(float x, float y, float z)
        {

        }
        public static MyQuatern EulerRotation(Vec3 euler)
        {

        }
        //
        // Resumen:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parámetros:
        //   fromDirection:
        //
        //   toDirection:
        public static MyQuatern FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {

        }
        //
        // Resumen:
        //     Returns the Inverse of rotation.
        //
        // Parámetros:
        //   rotation:
        public static MyQuatern Inverse(MyQuatern rotation)
        {

        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is clamped to the range [0, 1].
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static MyQuatern Lerp(MyQuatern a, MyQuatern b, float t)
        {

        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static MyQuatern LerpUnclamped(MyQuatern a, MyQuatern b, float t)
        {

        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static MyQuatern LookRotation(Vec3 forward)
        {

        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   forward:
        //     The direction to look in.
        //
        //   upwards:
        //     The vector that defines in which direction up is.
        public static MyQuatern LookRotation(Vec3 forward, [DefaultValue("Vector3.up")] Vec3 upwards)
        {

        }
        //
        // Resumen:
        //     Converts this quaternion to one with the same orientation but with a magnitude
        //     of 1.
        //
        // Parámetros:
        //   q:
        public static MyQuatern Normalize(MyQuatern q)
        {

        }
        //
        // Resumen:
        //     Rotates a rotation from towards to.
        //
        // Parámetros:
        //   from:
        //
        //   to:
        //
        //   maxDegreesDelta:
        public static MyQuatern RotateTowards(MyQuatern from, MyQuatern to, float maxDegreesDelta)
        {

        }
        //
        // Resumen:
        //     Spherically interpolates between quaternions a and b by ratio t. The parameter
        //     t is clamped to the range [0, 1].
        //
        // Parámetros:
        //   a:
        //     Start value, returned when t = 0.
        //
        //   b:
        //     End value, returned when t = 1.
        //
        //   t:
        //     Interpolation ratio.
        //
        // Devuelve:
        //     A quaternion spherically interpolated between quaternions a and b.
        public static MyQuatern Slerp(MyQuatern a, MyQuatern b, float t)
        {

        }
        //
        // Resumen:
        //     Spherically interpolates between a and b by t. The parameter t is not clamped.
        //
        // Parámetros:
        //   a:
        //
        //   b:
        //
        //   t:
        public static MyQuatern SlerpUnclamped(MyQuatern a, MyQuatern b, float t)
        {

        }
        public static Vec3 ToEulerAngles(MyQuatern rotation)
        {

        }
        public bool Equals(MyQuatern other)
        {

        }
        public override bool Equals(object other)
        {

        }
        public override int GetHashCode()
        {

        }
        public void Normalize()
        {

        }
        //
        // Resumen:
        //     Set x, y, z and w components of an existing Quaternion.
        //
        // Parámetros:
        //   newX:
        //
        //   newY:
        //
        //   newZ:
        //
        //   newW:
        public void Set(float newX, float newY, float newZ, float newW)
        {
            _x = newX;
            _y = newY;
            _z = newZ;
            _w = newW;
        }
        public void SetAxisAngle(Vec3 axis, float angle)
        {

        }
        public void SetEulerAngles(Vec3 euler)
        {

        }
        public void SetEulerAngles(float x, float y, float z)
        {

        }
        public void SetEulerRotation(float x, float y, float z)
        {

        }
        public void SetEulerRotation(Vector3 euler)
        {

        }
        //
        // Resumen:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        //
        // Parámetros:
        //   fromDirection:
        //
        //   toDirection:
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {

        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view, [DefaultValue("Vector3.up")] Vec3 up)
        {

        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        //
        // Parámetros:
        //   view:
        //     The direction to look in.
        //
        //   up:
        //     The vector that defines in which direction up is.
        public void SetLookRotation(Vec3 view)
        {

        }
        public void ToAngleAxis(out float angle, out Vec3 axis)
        {

        }
        public void ToAxisAngle(out Vec3 axis, out float angle)
        {

        }
        public Vec3 ToEuler()
        {

        }
        public Vec3 ToEulerAngles()
        {

        }
        #endregion

        #region Operators
        //public string ToString(string format)
        //{
        //
        //}        

        public override string ToString()
        {
            return "(" + _x.ToString() + ", " + _y.ToString() + ", " + _z.ToString() + ", " + _w.ToString() + ")";
        }

        public static Vec3 operator *(MyQuatern rotation, Vec3 point)
        {
            Vec3 convertQuat = new Vec3(rotation._x, rotation._y, rotation._z);
            float scalar = rotation._w;

            return new Vec3(point + 2 * scalar * (convertQuat * point) + 2 * (convertQuat * (convertQuat * point)));
        }

        public static MyQuatern operator *(MyQuatern lhs, MyQuatern rhs)
        {
            MyQuatern newQuatern = new MyQuatern(lhs._x * rhs._x, lhs._y * rhs._y, lhs._z * rhs._z, lhs._w * rhs._w);

            return newQuatern;
        }

        public static bool operator ==(MyQuatern lhs, MyQuatern rhs)
        {
            if ((lhs._x == rhs._x) && (lhs._y == rhs._y) && (lhs._z == rhs._z) && (lhs._w == rhs._w))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(MyQuatern lhs, MyQuatern rhs)
        {
            if ((lhs._x != rhs._x) || (lhs._y != rhs._y) || (lhs._z != rhs._z) || (lhs._w != rhs._w))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
