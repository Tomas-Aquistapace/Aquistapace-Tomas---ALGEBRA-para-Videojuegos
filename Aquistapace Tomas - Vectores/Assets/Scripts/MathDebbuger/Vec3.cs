using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { throw new NotImplementedException(); } }
        public Vec3 normalized { get { return new Vec3(x / magnitude, y / magnitude, z / magnitude); } }
        public float magnitude { get { return Mathf.Sqrt((x * x) + (y * y) + (z * z)); } }
        #endregion

        #region constants
        public const float epsilon = 1e-05f;
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            float diff_x = left.x - right.x;
            float diff_y = left.y - right.y;
            float diff_z = left.z - right.z;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrmag < epsilon * epsilon;
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - rightV3.x, leftV3.y - rightV3.y, leftV3.z - rightV3.z);
        }

        public static Vec3 operator -(Vec3 v3)
        {
            return new Vec3(-v3.x, -v3.y, -v3.z);
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }

        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }

        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x / scalar, v3.y / scalar, v3.z / scalar);
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
        }
        #endregion

        #region Functions
        public override string ToString() // --- FUNCIONA ---- PERO ---- acomodar para que no tenga tantos numeros despues de la coma
        {
            return "(" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ")";
        }
        
        public static float Angle(Vec3 from, Vec3 to) // --- FUNCIONA
        {
            float produc = Dot(from, to);
            float mag = Magnitude(from) * Magnitude(to);
            float ang = produc / mag;
            return ang = Mathf.Acos(ang) * Mathf.Rad2Deg;
            // cuando se realiza la multiplicacion del coceno (Mathf.Acos), se pone -Acos- porque
            // cuando se hacen los pasajes y se pasa el coceno al otro lado del calculo, se pasa como negativo, por esa razon exise -Acos-, que es la version NEGATIVA del Cos.


            // aca es donde se utilizan los radianes como una multiplicacion por parte de Unity,
            // sino, esta la opcion de hacerlo a mano: -Mathf.Acos(ang) / (Mathf.PI / 180)-
            // que existe para pasar los grados a un numero interpretable por el usuario.
        }

        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength) // --- FUNCIONA
        {
            if (Magnitude(vector) > maxLength) {
                vector.Normalize();
                vector = new Vec3(vector.x * maxLength, vector.y * maxLength, vector.z * maxLength);
            }
            return vector;
        }

        public static float Magnitude(Vec3 vector) // --- FUNCIONA
        {
            return Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z));
        }

        public static Vec3 Cross(Vec3 a, Vec3 b) // --- FUNCIONA
        {// Se utiliza para crear un nuevo vector "ortogonal" a los dos vectores ingresados
            float newX = (a.y * b.z) - (a.z * b.y);
            float newY = -((a.x * b.z) - (a.z * b.x));
            float newZ = (a.x * b.y) - (a.y * b.x);

            return new Vec3(newX, newY, newZ);
        }

        public static float Distance(Vec3 a, Vec3 b) // --- FUNCIONA
        {
            Vec3 c = new Vec3(b.x - a.x, b.y - a.y, b.z - a.z);
            float dist = Mathf.Sqrt(Mathf.Pow(c.x, 2) + Mathf.Pow(c.y, 2) + Mathf.Pow(c.z, 2));
            return dist;
        }

        public static float Dot(Vec3 a, Vec3 b) // --- FUNCIONA
        { // sirve para sacar el angulo entre dos vectores
            float dot = (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
            return dot;
        }

        public static Vec3 Lerp(Vec3 a, Vec3 b, float t) // --- FUNCIONA
        {
            if (t < 0)
            {
                t = 0;
            }
            if (t > 1)
            {
                t = 1;
            }
            // Y = M * X + B
            // PuntoActual = (Destino - Origen) * Tiempo + OrdenadaAlOrigen
            float newX = (b.x - a.x) * t + a.x;
            float newY = (b.y - a.y) * t + a.y;
            float newZ = (b.z - a.z) * t + a.z;
            return new Vec3(newX, newY, newZ);
        }

        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t) // --- FUNCIONA
        {
            // Y = M * X + B
            // PuntoActual = (Destino - Origen) * Tiempo + OrdenadaAlOrigen
            float newX = (b.x - a.x) * t + a.x;
            float newY = (b.y - a.y) * t + a.y;
            float newZ = (b.z - a.z) * t + a.z;
            return new Vec3(newX, newY, newZ);
        }

        public static Vec3 Max(Vec3 a, Vec3 b) // --- FUNCIONA
        { // elige los MAYORES valores de los dos vectores, y forma un solo vector con esos valores
            float newX;
            float newY;
            float newZ;

            if (a.x > b.x) newX = a.x;
            else newX = b.x;

            if (a.y > b.y) newY = a.y;
            else newY = b.y;

            if (a.z > b.z) newZ = a.z;
            else newZ = b.z;

            return new Vec3(newX, newY, newZ);
        }

        public static Vec3 Min(Vec3 a, Vec3 b) // --- FUNCIONA
        { // elige los MENORES valores de los dos vectores, y forma un solo vector con esos valores
            float newX;
            float newY;
            float newZ;

            if (a.x < b.x) newX = a.x;
            else newX = b.x;

            if (a.y < b.y) newY = a.y;
            else newY = b.y;

            if (a.z < b.z) newZ = a.z;
            else newZ = b.z;

            return new Vec3(newX, newY, newZ);
        }

        public static float SqrMagnitude(Vec3 vector) // --- FUNCIONA
        { // Se utiliza para ahorrar recursos cuando se utiliza MAGNITUD, al quitar la raiz cuadrada del calculo. WARNING, se trabaja con otra escala gracias a eso
            return (vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z);
        }

        public static Vec3 Project(Vec3 vector, Vec3 onNormal) // --- FUNCIONA
        {
            // Project = ProductoPunto / Magnitude de onNormal * Magnitude de onNormal

            return (Dot(vector, onNormal) / Mathf.Pow(Magnitude(onNormal), 2)) * onNormal;
        }

        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal) // --- ARREGLAR - Preguntar a lean que pasa ------------------------------------------
        {
            Vec3 N = inNormal;
            N.Normalize();

            //Vec3 Ncuad = new Vec3(N.x * N.x, N.y * N.y, N.z * N.z);

            return new Vec3(inDirection - 2*(Dot(inDirection, N) * N));

            //return new Vec3(inDirection - ((Dot(2 * inDirection, N) / (N * N)) * N));
        }

        public void Set(float newX, float newY, float newZ) // --- FUNCIONA
        {
            this = new Vec3(newX, newY, newZ);
        }

        public void Scale(Vec3 scale) // --- FUNCIONA
        {
            this = new Vec3(this.x * scale.x, this.y * scale.y, this.z * scale.z);
        }

        public void Normalize() // --- FUNCIONA
        { // se utiliza para convertirlo en un vector "Normalizado" o "Estandar", que tiene 1 de Magnitud
            this = new Vec3(this.x / Magnitude(this), this.y / Magnitude(this), this.z / Magnitude(this));
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}