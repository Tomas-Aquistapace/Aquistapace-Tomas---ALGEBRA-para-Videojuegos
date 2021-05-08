using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

namespace CustomPlane
{
    public struct MyPlane
    {
        #region Variables
        Vec3 _posA;
        Vec3 _posB;
        Vec3 _posC;
        Vec3 _normal;
        float _distance;
        Vec3 _flipped;
        #endregion

        #region Properties
        public float Distance()
        {
            return _distance;
        }

        public Vec3 Flipped()
        {
            return _flipped;
        }

        public Vec3 Normal()
        {
            return _normal;
        }
        #endregion

        #region Constructors
        public MyPlane(Vec3 inNormal, Vec3 inPoint)
        {
            Vec3 newNormalB = new Vec3(inNormal.x, -inNormal.z, 0);
            Vec3 newNormalC = new Vec3(0, inNormal.x, inNormal.y);

            _posA = inPoint;
            _posB = inPoint + newNormalB;
            _posC = inPoint + newNormalC;

            _normal = inNormal;
            _distance = Vec3.Dot(-_posA, _normal) / Vec3.Magnitude(_normal);
            _flipped = -_normal;
        }

        public MyPlane(Vec3 A, Vec3 B, Vec3 C)
        {
            _posA = A; _posB = B; _posC = C;

            Vec3 pointA = _posB - _posA;
            Vec3 pointB = _posC - _posA;

            _normal = Vec3.Cross(pointA, pointB);
            _distance = Vec3.Dot(-_posA, _normal) / Vec3.Magnitude(_normal);
            _flipped = -_normal;
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return "Normal: " + _normal.ToString() + ", Distance: " + _distance;
        }

        public Vec3 ClosestPointOnPlane(Vec3 point) // Por el punto dado se obtiene el punto del plano mas cercano
        {
            Vec3 newVec = point;



            return newVec;
        }

        public void Flip() // Da vuelta el plano para que mire al lado contrario al que estaba
        {
            _normal = _normal * -1;
        }

        public float GetDistanceToPoint(Vec3 point) // Obtiene una distancia POSITIVA si el punto esta del lado frontal del plano, y NEGATIVA si el punto esta del lado opuesto
        {
            return Vec3.Dot(point -_posA, _normal) / Vec3.Magnitude(_normal);
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
            _posA = A; _posB = B; _posC = C;

            Vec3 pointA = _posB - _posA;
            Vec3 pointB = _posC - _posA;

            _normal = Vec3.Cross(pointA, pointB);
            _distance = Vec3.Dot(-_posA, _normal) / Vec3.Magnitude(_normal);
            _flipped = -_normal;
        }

        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint) // setea una nueva normal y posicion al plano
        {
            Vec3 newNormalB = new Vec3(inNormal.x, -inNormal.z, 0);
            Vec3 newNormalC = new Vec3(0, inNormal.x, inNormal.y);

            _posA = inPoint;
            _posB = inPoint + newNormalB;
            _posC = inPoint + newNormalC;

            _normal = inNormal;
            _distance = Vec3.Dot(-_posA, _normal) / Vec3.Magnitude(_normal);
            _flipped = -_normal;
        }

        //public static MyPlane Translate(MyPlane plane, Vec3 translation)
        //{
        //    
        //}
        #endregion
    }
}