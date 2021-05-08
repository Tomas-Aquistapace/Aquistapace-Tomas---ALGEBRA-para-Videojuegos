﻿using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using CustomPlane;

public class PlanesTarea : MonoBehaviour
{
    public Transform cube;

    public Transform leftObjTrans;    
    public Transform rightObjTrans;    
    public Transform nearObjTrans;    
    public Transform farObjTrans;
    public Transform topObjTrans;
    public Transform downObjTrans;

    Plane _planeLeft;
    Plane _planeRight;
    Plane _planeNear;
    Plane _planeFar;
    Plane _planeTop;
    Plane _planeDown;

    void Start()
    {
        Vec3 leftPlaneNormal = new Vec3(leftObjTrans.right);
        Vec3 rightPlaneNormal = new Vec3(rightObjTrans.right);
        Vec3 nearPlaneNormal = new Vec3(nearObjTrans.right);
        Vec3 farPlaneNormal = new Vec3(farObjTrans.right);
        Vec3 topPlaneNormal = new Vec3(topObjTrans.right);
        Vec3 downPlaneNormal = new Vec3(downObjTrans.right);

        Vec3 leftPlanePosition = new Vec3(leftObjTrans.localPosition);
        Vec3 rightPlanePosition = new Vec3(rightObjTrans.localPosition);
        Vec3 nearPlanePosition = new Vec3(nearObjTrans.localPosition);
        Vec3 farPlanePosition = new Vec3(farObjTrans.localPosition);
        Vec3 topPlanePosition = new Vec3(topObjTrans.localPosition);
        Vec3 downPlanePosition = new Vec3(downObjTrans.localPosition);

        _planeLeft = new Plane(leftPlaneNormal, leftPlanePosition);
        _planeRight = new Plane(rightPlaneNormal, rightPlanePosition);
        _planeNear = new Plane(nearPlaneNormal, nearPlanePosition);
        _planeFar = new Plane(farPlaneNormal, farPlanePosition);
        _planeTop = new Plane(topPlaneNormal, topPlanePosition);
        _planeDown = new Plane(downPlaneNormal, downPlanePosition);

        // ----------------------------------
        // prueba de mis planos

        //Vector3 V1 = new Vector3(1,5,6);
        //Vector3 V2 = new Vector3(4,10,3);
        //Vector3 V3 = new Vector3(9,4,7);
        //
        //Vec3 VM1 = new Vec3(V1);
        //Vec3 VM2 = new Vec3(V2);
        //Vec3 VM3 = new Vec3(V3);
        //
        //Plane planoU = new Plane(V1, V2);
        //MyPlane plano1 = new MyPlane(VM1, VM2);
        //
        //Debug.Log(planoU);
        //Debug.Log(plano1);
        //
        //Debug.Log(planoU.GetDistanceToPoint(V3));
        //Debug.Log(plano1.GetDistanceToPoint(VM3));
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (DetectObject(cube))
            {
                Debug.Log("adentro");
            }
            else
            {
                Debug.Log("afuera");
            }
        }
    }

    bool DetectObject(Transform cube)
    {
        //Debug.Log("Near: " + _planeNear.GetSide(cube.transform.position));
        //Debug.Log("Right: " + _planeRight.GetSide(cube.transform.position));
        //Debug.Log("Left: " + _planeLeft.GetSide(cube.transform.position));
        //Debug.Log("Down: " + _planeDown.GetSide(cube.transform.position));
        //Debug.Log("Top: " + _planeTop.GetSide(cube.transform.position));
        Debug.Log("Far: " + _planeFar.GetSide(cube.transform.position));

        if (_planeNear.GetSide(cube.transform.position) && _planeRight.GetSide(cube.transform.position) && _planeLeft.GetSide(cube.transform.position) &&
             _planeDown.GetSide(cube.transform.position) && _planeTop.GetSide(cube.transform.position) && _planeFar.GetSide(cube.transform.position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
