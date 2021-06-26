using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomQuatern;
using CustomMath;

public class QuaternionTester : MonoBehaviour
{
    public enum Funciones
    {
        Uno, Dos, Tres
    }

    public Funciones ejercicio;
    public Color colorVec;

    public float valor;
    public Vector3 resultado = Vector3.zero;

    void Start()
    {
        Vector3Debugger.AddVector(resultado, colorVec, "elRojo");
        Vector3Debugger.EnableEditorView("elResultado");

        // -----------------------------------

        Vec3 myVec1 = new Vec3(2, 5.1f, 7.54f);
        Vec3 myVec2 = new Vec3(1.5f, 3, 4.4f);

        Vector3 unVec1 = new Vector3(2, 5.1f, 7.54f);
        Vector3 unVec2 = new Vector3(1.5f, 3, 4.4f);

        //MyQuatern myQuater = new MyQuatern(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //Quaternion unityQuater = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        MyQuatern myQuat1 = MyQuatern.Euler(myVec1);
        MyQuatern myQuat2 = MyQuatern.Euler(myVec2);

        //Quaternion uniQuat1 = Quaternion.FromToRotation(unVec1, unVec2);

        Quaternion uniQuat1 = Quaternion.Euler(unVec1);
        Quaternion uniQuat2 = Quaternion.Euler(unVec2);

        //Vec3 algo = MyQuatern.Angle();
        //Vector3 algo2 = unityQuater.eulerAngles;

        MyMatrix4x4 miMatrix = MyMatrix4x4.Rotate(myQuat1);
        Matrix4x4 uniMatrix = Matrix4x4.Rotate(uniQuat1);

        Debug.Log("Mio: " + miMatrix);
        Debug.Log("Unity: " + uniMatrix);
    }

    void Update()
    {
        Vec3 A = new Vec3(resultado);

        switch (ejercicio)
        {
            case Funciones.Uno:

                

                break;

            case Funciones.Dos:

                

                break;

            case Funciones.Tres:

                

                break;
        }
        resultado = A;

        Vector3Debugger.UpdatePosition("elRojo", resultado);
    }
}