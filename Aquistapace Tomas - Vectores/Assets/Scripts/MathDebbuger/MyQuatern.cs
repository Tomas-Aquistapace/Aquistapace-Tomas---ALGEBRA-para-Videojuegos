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
        #region Contructors
        public const float kEpsilon = 1E-06F;
        public float x;
        public float y;
        public float z;
        public float w;

        public MyQuatern(float _x, float _y, float _z, float _w)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
            this.w = _w;
        }
        public MyQuatern(MyQuatern quatern)
        {
            this.x = quatern.x;
            this.y = quatern.y;
            this.z = quatern.z;
            this.w = quatern.w;
        }
        public MyQuatern(Quaternion quatern)
        {
            this.x = quatern.x;
            this.y = quatern.y;
            this.z = quatern.z;
            this.w = quatern.w;
        }
        #endregion

        #region Properties
        public float this[int index] 
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public static MyQuatern identity 
        { 
            get
            {
                throw new NotImplementedException();
            }
        }
        public Vec3 eulerAngles 
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public Quaternion normalized 
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion


        #region Public Methods
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
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
        public void ToAngleAxis(out float angle, out Vec3 axis)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ", " + w.ToString() + ")";
        }
        #endregion

        #region Static Methods
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
            //float produc = (a._x * b._x) + (a._y * b._y) + (a._z * b._z) + (a._w * b._w);
            //
            //float magnitudA = Mathf.Sqrt((a._x * a._x) + (a._y * a._y) + (a._z * a._z) + (a._w * a._w));
            //float magnitudA = Mathf.Sqrt((a._x * a._x) + (a._y * a._y) + (a._z * a._z) + (a._w * a._w));
            //
            //float mag = Magnitude(a) * Magnitude(b);
            //
            //float ang = produc / mag;
            //
            //return ang = Mathf.Acos(ang) * Mathf.Rad2Deg;

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public static MyQuatern AxisAngle(Vector3 axis, float angle)
        {
            throw new NotImplementedException();
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
            float sinAngleX = Mathf.Sin(Mathf.Deg2Rad * euler.x * 0.5f);
            float cosAngleX = Mathf.Cos(Mathf.Deg2Rad * euler.x * 0.5f);
            MyQuatern qx = new MyQuatern(sinAngleX, 0, 0, cosAngleX);

            float sinAngleY = Mathf.Sin(Mathf.Deg2Rad * euler.y * 0.5f);
            float cosAngleY = Mathf.Cos(Mathf.Deg2Rad * euler.y * 0.5f);
            MyQuatern qy = new MyQuatern(0, sinAngleY, 0, cosAngleY);

            float sinAngleZ = Mathf.Sin(Mathf.Deg2Rad * euler.z * 0.5f);
            float cosAngleZ = Mathf.Cos(Mathf.Deg2Rad * euler.z * 0.5f);
            MyQuatern qz = new MyQuatern(0, 0, sinAngleZ, cosAngleZ);

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
            throw new NotImplementedException();
        }
        public static MyQuatern EulerAngles(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        public static MyQuatern EulerAngles(Vec3 euler)
        {
            throw new NotImplementedException();
        }
        public static MyQuatern EulerRotation(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
        public static MyQuatern EulerRotation(Vec3 euler)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Returns the Inverse of rotation.
        //
        // Parámetros:
        //   rotation:
        public static MyQuatern Inverse(MyQuatern rotation)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        #endregion


        // --------------- \\
        #region EXTRAS RANDOM
        public static Vec3 ToEulerAngles(MyQuatern rotation)
        {
            throw new NotImplementedException();
        }
        public bool Equals(MyQuatern other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public void Normalize()
        {

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
        
        public void ToAxisAngle(out Vec3 axis, out float angle)
        {
            throw new NotImplementedException();
        }
        public Vec3 ToEuler()
        {
            throw new NotImplementedException();
        }
        public Vec3 ToEulerAngles()
        {
            throw new NotImplementedException();
        }
        #endregion
        // --------------- \\


        #region Operators
        public static Vec3 operator *(MyQuatern rotation, Vec3 point)
        {
            Vec3 convertQuat = new Vec3(rotation.x, rotation.y, rotation.z);
            float scalar = rotation.w;

            return new Vec3(point + 2 * scalar * (convertQuat * point) + 2 * (convertQuat * (convertQuat * point)));
        }

        public static MyQuatern operator *(MyQuatern lhs, MyQuatern rhs)
        {
            float x = lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y;
            float y = lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x;
            float z = lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w;
            float w = lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z;

            //  C.x =    A.w * B.x    +    A.x * B.w    +    A.y * B.z    -    A.z * B.y;
            //  C.y =    A.w * B.y    -    A.x * B.z    +    A.y * B.w    +    A.z * B.x;
            //  C.z =    A.w * B.z    +    A.x * B.y    -    A.y * B.x    +    A.z * B.w;
            //  C.w =    A.w * B.w    -    A.x * B.x    -    A.y * B.y    -    A.z * B.z;

            return new MyQuatern(x, y, z, w);
        }

        public static bool operator ==(MyQuatern lhs, MyQuatern rhs)
        {
            if ((lhs.x == rhs.x) && (lhs.y == rhs.y) && (lhs.z == rhs.z) && (lhs.w == rhs.w))
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
            if ((lhs.x != rhs.x) || (lhs.y != rhs.y) || (lhs.z != rhs.z) || (lhs.w != rhs.w))
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
