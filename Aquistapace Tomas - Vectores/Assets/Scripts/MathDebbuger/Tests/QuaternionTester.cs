using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomQuatern;
using CustomMath;

public class QuaternionTester : MonoBehaviour
{
    void Start()
    {
        Vec3 myVec1 = new Vec3(2, 5.1f, 7.54f);
        Vec3 myVec2 = new Vec3(1.5f, 3, 4.4f);

        Vector3 unVec1 = new Vector3(2, 5.1f, 7.54f);
        Vector3 unVec2 = new Vector3(1.5f, 3, 4.4f);

        //MyQuatern myQuater = new MyQuatern(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //Quaternion unityQuater = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        MyQuatern myQuat1 = MyQuatern.Euler(myVec1);
        MyQuatern myQuat2 = MyQuatern.Euler(myVec2);

        Quaternion uniQuat1 = Quaternion.FromToRotation(unVec1, unVec2);

        //Vec3 algo = MyQuatern.Angle();
        //Vector3 algo2 = unityQuater.eulerAngles;

        Debug.Log("Iña: " + MyQuatern.FromToRotation(myVec1, myVec2));
        Debug.Log("Unity: " + uniQuat1.x + ", " + uniQuat1.y + ", " + uniQuat1.z + ", " + uniQuat1.w);
        Debug.Log("-------------------");
        //Debug.Log("Mio:" + algo);
        //Debug.Log("Unity:" + algo2);
    }
}
