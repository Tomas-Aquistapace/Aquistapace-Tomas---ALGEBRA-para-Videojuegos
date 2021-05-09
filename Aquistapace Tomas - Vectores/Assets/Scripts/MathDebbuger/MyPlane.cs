using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

namespace CustomPlane
{
    public struct MyPlane
    {
        #region Variables
        Vec3 _normal;
        float _distance;
        #endregion

        #region Properties
        public float Distance()
        {
            return _distance;
        }

        public Vec3 Flipped()
        {
            return -_normal;
        }

        public Vec3 Normal()
        {
            return _normal;
        }
        #endregion

        #region Constructors
        public MyPlane(Vec3 inNormal, Vec3 inPoint)
        {
            _normal = inNormal.normalized;
            _distance = -Vec3.Dot(_normal, inPoint);
        }

        public MyPlane(Vec3 A, Vec3 B, Vec3 C)
        {
            // se sacan dos Vectores perpendiculares al plano utilizando B y C
            // B - A y C - A

            _normal = Vec3.Cross(B - A, C - A).normalized;
            _distance = -Vec3.Dot(_normal, A);
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return "Normal: " + _normal.ToString() + ", Distance: " + _distance;
        }

        public Vec3 ClosestPointOnPlane(Vec3 point) // Por el punto dado se obtiene el punto del plano mas cercano
        {
            return (point - _normal * GetDistanceToPoint(point));
        }

        public void Flip() // Da vuelta el plano para que mire al lado contrario al que estaba
        {
            _normal = _normal * -1;
            _distance = _distance * -1;
        }

        public float GetDistanceToPoint(Vec3 point) // Obtiene una distancia POSITIVA si el punto esta del lado frontal del plano, y NEGATIVA si el punto esta del lado opuesto
        {
            return Vec3.Dot(point, _normal) + _distance / Vec3.Magnitude(_normal);
        }

        public bool GetSide(Vec3 point) // Pregunta si el punto esta del lado positivo del plano
        {
            return GetDistanceToPoint(point) > 0;
        }

        // Raycast

        public bool SameSide(Vec3 inPt0, Vec3 inPt1) // Pregunta si ambos puntos estan del lado positivo del plano
        {
            if (GetDistanceToPoint(inPt0) > 0 && GetDistanceToPoint(inPt1) > 0)
                return true;
            else
                return false;
        }

        public void Set3Points(Vec3 A, Vec3 B, Vec3 C) // setea 3 puntos nuevos que componen al plano
        {
            _normal = Vec3.Cross(B - A, C - A);
            _distance = -Vec3.Dot(_normal, A);
        }

        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint) // setea una nueva normal y posicion al plano
        {
            _normal = inNormal;
            _distance = -Vec3.Dot(_normal, inPoint);
        }

        //public static MyPlane Translate(MyPlane plane, Vec3 translation) // No supe como hacer que funcione con un solo vec3 que se le ingresa
        //{
        //    plane._normal = translation.normalized;
        //    plane._distance = -Vec3.Dot(plane._normal, translation);
        //
        //    return plane;
        //}
        #endregion
    }
}