using UnityEngine;
using CustomMath;
using CustomPlane;

public class PlanesTarea : MonoBehaviour
{
    public GameObject cubeTest;
    Vec3 cubePosition;

    public Transform leftObjTrans;
    public Transform rightObjTrans;
    public Transform nearObjTrans;
    public Transform farObjTrans;
    public Transform topObjTrans;
    public Transform downObjTrans;

    MyPlane _planeLeft;
    MyPlane _planeRight;
    MyPlane _planeNear;
    MyPlane _planeFar;
    MyPlane _planeTop;
    MyPlane _planeDown;

    Vec3 leftPlaneNormal;
    Vec3 rightPlaneNormal;
    Vec3 nearPlaneNormal;
    Vec3 farPlaneNormal;
    Vec3 topPlaneNormal;
    Vec3 downPlaneNormal;

    Vec3 leftPlanePosition;
    Vec3 rightPlanePosition;
    Vec3 nearPlanePosition;
    Vec3 farPlanePosition;
    Vec3 topPlanePosition;
    Vec3 downPlanePosition;

    // -----------------------------
    const float SPEED_ROTATION = 20;
    Vec3 ROTATION_AXIS = new Vec3(0,5,0);
    Vec3 ROTATE_POINT = Vec3.Zero;
    // -----------------------------

    void Start()
    {
        UpdatePositionObjects();

        _planeLeft = new MyPlane(leftPlaneNormal, leftPlanePosition);
        _planeRight = new MyPlane(rightPlaneNormal, rightPlanePosition);
        _planeNear = new MyPlane(nearPlaneNormal, nearPlanePosition);
        _planeFar = new MyPlane(farPlaneNormal, farPlanePosition);
        _planeTop = new MyPlane(topPlaneNormal, topPlanePosition);
        _planeDown = new MyPlane(downPlaneNormal, downPlanePosition);
    }

    void Update()
    {
        RotateObjects();
        UpdatePositionObjects();
        MovePlanes();

        if (DetectObject(cubePosition))
        {
            cubeTest.SetActive(true);
        }
        else
        {
            cubeTest.SetActive(false);
        }
    }

    void UpdatePositionObjects()
    {
        cubePosition = new Vec3(cubeTest.transform.position);

        leftPlaneNormal = new Vec3(leftObjTrans.right);
        rightPlaneNormal = new Vec3(rightObjTrans.right);
        nearPlaneNormal = new Vec3(nearObjTrans.right);
        farPlaneNormal = new Vec3(farObjTrans.right);
        topPlaneNormal = new Vec3(topObjTrans.right);
        downPlaneNormal = new Vec3(downObjTrans.right);

        leftPlanePosition = new Vec3(leftObjTrans.localPosition);
        rightPlanePosition = new Vec3(rightObjTrans.localPosition);
        nearPlanePosition = new Vec3(nearObjTrans.localPosition);
        farPlanePosition = new Vec3(farObjTrans.localPosition);
        topPlanePosition = new Vec3(topObjTrans.localPosition);
        downPlanePosition = new Vec3(downObjTrans.localPosition);
    }

    void MovePlanes()
    {
        _planeLeft.SetNormalAndPosition(leftPlaneNormal, leftPlanePosition);
        _planeRight.SetNormalAndPosition(rightPlaneNormal, rightPlanePosition);
        _planeNear.SetNormalAndPosition(nearPlaneNormal, nearPlanePosition);
        _planeFar.SetNormalAndPosition(farPlaneNormal, farPlanePosition);
        _planeTop.SetNormalAndPosition(topPlaneNormal, topPlanePosition);
        _planeDown.SetNormalAndPosition(downPlaneNormal, downPlanePosition);
    }

    void RotateObjects()
    {
        leftObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        rightObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        nearObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        farObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        topObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
        downObjTrans.RotateAround(ROTATE_POINT, ROTATION_AXIS, SPEED_ROTATION * Time.deltaTime);
    }

    bool DetectObject(Vec3 cubePos)
    {
        if (_planeNear.GetSide(cubePos) && _planeRight.GetSide(cubePos) && _planeLeft.GetSide(cubePos) &&
         _planeDown.GetSide(cubePos) && _planeTop.GetSide(cubePos) && _planeFar.GetSide(cubePos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
