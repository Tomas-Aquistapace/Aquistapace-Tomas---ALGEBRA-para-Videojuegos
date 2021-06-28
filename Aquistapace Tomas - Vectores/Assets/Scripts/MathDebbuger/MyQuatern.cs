using UnityEngine.Internal;
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
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Index");
                }
            }
        }
        public static MyQuatern identity 
        {
            get
            {
                return new MyQuatern(0, 0, 0, 1);
            }
        }
        public Vec3 eulerAngles
        {
            get
            {
                Vec3 newEuler;

                newEuler.x = Mathf.Rad2Deg * Mathf.Asin(x * 2);
                newEuler.y = Mathf.Rad2Deg * Mathf.Asin(y * 2);
                newEuler.z = Mathf.Rad2Deg * Mathf.Asin(z * 2);

                return newEuler;
            }
            set
            {
                MyQuatern quat = Euler(value);
                this.x = quat.x;
                this.y = quat.y;
                this.z = quat.z;
                this.w = quat.w;
            }
        }
        public MyQuatern normalized
        {
            get
            {
                // Magnitud
                float mag = Mathf.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
                // Normalize
                return new MyQuatern(this.x / mag, this.y / mag, this.z / mag, this.w / mag);
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
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        public void SetLookRotation(Vec3 view, [DefaultValue("Vector3.up")] Vec3 up)
        {
            throw new NotImplementedException();
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
        public static float Angle(MyQuatern a, MyQuatern b)
        {
            // Acos(modulo(Dot(a,b)) * 2 * (pi / 180);
            
            MyQuatern inv = Inverse(a);
            MyQuatern result = b * inv;

            float angle = Mathf.Acos(result.w) * 2f * Mathf.Rad2Deg;
            return angle;
        }
        //
        // Resumen:
        //     Creates a rotation which rotates angle degrees around axis.
        public static MyQuatern AngleAxis(float angle, Vec3 axis)
        {
            if (axis.sqrMagnitude == 0)
                return identity;

            angle *= Mathf.Deg2Rad * 0.5f;
            axis.Normalize();
            MyQuatern result = identity;
            axis = axis * (float)Math.Sin(angle);
            result.x = axis.x;
            result.y = axis.y;
            result.z = axis.z;
            result.w = (float)Math.Cos(angle);

            return Normalize(result);
        }
        //
        // Resumen:
        //     The dot product between two rotations.
        public static float Dot(MyQuatern a, MyQuatern b)
        {
            float produc = (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
            return produc;
        }
        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis.
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

            return new MyQuatern(qx * qy * qz);
        }
        //
        // Resumen:
        //     Returns a rotation that rotates z degrees around the z axis, x degrees around
        //     the x axis, and y degrees around the y axis; applied in that order.
        public static MyQuatern Euler(float x, float y, float z)
        {
            return Euler(new Vec3(x, y, z));
        }
        //
        // Resumen:
        //     Creates a rotation which rotates from fromDirection to toDirection.
        public static MyQuatern FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Vec3 cross = Vec3.Cross(fromDirection, toDirection);
            MyQuatern q;
            q.x = cross.x;
            q.y = cross.y;
            q.z = cross.z;
            q.w = fromDirection.magnitude * toDirection.magnitude + Vec3.Dot(fromDirection, toDirection);
            q.Normalize();
            return q;
        }
        //
        // Resumen:
        //     Returns the Inverse of rotation.
        public static MyQuatern Inverse(MyQuatern rotation)
        {
            return new MyQuatern(-rotation.x, -rotation.y, -rotation.z, rotation.w);
        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is clamped to the range [0, 1].
        public static MyQuatern Lerp(MyQuatern a, MyQuatern b, float t)
        {
            float time = Mathf.Clamp(t, 0, 1);
            return LerpUnclamped(a,b,time);
        }
        //
        // Resumen:
        //     Interpolates between a and b by t and normalizes the result afterwards. The parameter
        //     t is not clamped.
        public static MyQuatern LerpUnclamped(MyQuatern a, MyQuatern b, float t)
        {
            // Y = M * X + B
            // PuntoActual = (Destino - Origen) * Tiempo + OrdenadaAlOrigen
            MyQuatern actQuat;
            actQuat.x = (b.x - a.x) * t + a.x;
            actQuat.y = (b.y - a.y) * t + a.y;
            actQuat.z = (b.z - a.z) * t + a.z;
            actQuat.w = (b.w - a.w) * t + a.w;
            return actQuat;
        }
        //
        // Resumen:
        //     Creates a rotation with the specified forward and upwards directions.
        public static MyQuatern LookRotation(Vec3 forward, [DefaultValue("Vector3.up")] Vec3 upwards)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Converts this quaternion to one with the same orientation but with a magnitude
        //     of 1.
        public static MyQuatern Normalize(MyQuatern q)
        {
            return q.normalized;
        }
        //
        // Resumen:
        //     Rotates a rotation from towards to.
        public static MyQuatern RotateTowards(MyQuatern from, MyQuatern to, float maxDegreesDelta)
        {
            throw new NotImplementedException();
        }
        //
        // Resumen:
        //     Spherically interpolates between quaternions a and b by ratio t. The parameter
        //     t is clamped to the range [0, 1].
        public static MyQuatern Slerp(MyQuatern a, MyQuatern b, float t)
        {
            float time = Mathf.Clamp(t, 0, 1);
            return SlerpUnclamped(a, b, time);
        }
        //
        // Resumen:
        //     Spherically interpolates between a and b by t. The parameter t is not clamped.
        public static MyQuatern SlerpUnclamped(MyQuatern a, MyQuatern b, float t)
        {
            MyQuatern quatInterpolated = identity;

            float cosHalfTheta = Dot(a, b);
            if (cosHalfTheta < 0)
            {
                b.w = -b.w;
                b.x = -b.x;
                b.y = -b.y;
                b.z = -b.z;
                cosHalfTheta = -cosHalfTheta;
            }
            if (Mathf.Abs(cosHalfTheta) >= 1f)
            {
                quatInterpolated.Set(a.x, a.y, a.z, a.w);
                return quatInterpolated;
            }
            float halfTheta = Mathf.Acos(cosHalfTheta);
            float sinHalfTheta = Mathf.Sqrt(1 - cosHalfTheta * cosHalfTheta);
            if (Mathf.Abs(sinHalfTheta) < 0.001f)
            {
                quatInterpolated.w = (a.w * 0.5f + b.w * 0.5f);
                quatInterpolated.x = (a.x * 0.5f + b.x * 0.5f);
                quatInterpolated.y = (a.y * 0.5f + b.y * 0.5f);
                quatInterpolated.z = (a.z * 0.5f + b.z * 0.5f);
                return quatInterpolated;
            }
            float ratioA = Mathf.Sin((1 - t) * halfTheta) / sinHalfTheta;
            float ratioB = Mathf.Sin(t * halfTheta) / sinHalfTheta;
            quatInterpolated.w = (a.w * ratioA + b.w * ratioB);
            quatInterpolated.x = (a.x * ratioA + b.x * ratioB);
            quatInterpolated.y = (a.y * ratioA + b.y * ratioB);
            quatInterpolated.z = (a.z * ratioA + b.z * ratioB);
            return quatInterpolated;
        }
        public void Normalize()
        {
            // Magnitud
            float mag = Mathf.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
            // Normalize
            this = new MyQuatern(this.x / mag, this.y / mag, this.z / mag, this.w / mag);
        }
        #endregion

        #region Operators
        public static Vec3 operator *(MyQuatern rotation, Vec3 point)
        {
            float num = rotation.x * 2;
            float num2 = rotation.y * 2;
            float num3 = rotation.z * 2;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            Vec3 result;
            result.x = (1 - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1 - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1 - (num4 + num5)) * point.z;
            return result;
        }

        public static MyQuatern operator *(MyQuatern lhs, MyQuatern rhs)
        {
            float x = lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y;
            float y = lhs.w * rhs.y - lhs.x * rhs.z + lhs.y * rhs.w + lhs.z * rhs.x;
            float z = lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x + lhs.z * rhs.w;
            float w = lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z;

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

        #region Interface
        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.w.GetHashCode() >> 1;
        }
        public bool Equals(MyQuatern other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z) && this.w.Equals(other.w);
        }
        public override bool Equals(object other)
        {
            if (!(other is MyQuatern))
                return false;
            return Equals((MyQuatern)other);
        }
        #endregion
    }
}
