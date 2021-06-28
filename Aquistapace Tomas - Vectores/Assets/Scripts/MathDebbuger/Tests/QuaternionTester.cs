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

    public float valor;

    Vector3 ejer1 = Vector3.zero;
    List<Vector3> ejer2 = new List<Vector3>();
    List<Vector3> ejer3 = new List<Vector3>();

    void Start()
    {
        Vector3Debugger.AddVector(ejer1, Color.red, "primero");
        ejer1 = new Vector3(5, 0, 0);       


        Vector3Debugger.AddVectorsSecuence(ejer2, false, Color.blue, "segundo");
        ejer2.Add(new Vector3(5, 0, 0));
        ejer2.Add(new Vector3(5, 5, 0));
        ejer2.Add(new Vector3(10, 5, 0));


        Vector3Debugger.AddVectorsSecuence(ejer3, false, Color.yellow, "tercero");
        ejer3.Add(new Vector3(5, 0, 0));
        ejer3.Add(new Vector3(5, 5, 0));
        ejer3.Add(new Vector3(10, 5, 0));
        ejer3.Add(new Vector3(10, 10, 0));
    }

    void FixedUpdate()
    {
        //transform.rotation = transform.rotation * Quaternion.AngleAxis(valor, Vector3.up);
        //transform.rotation = transform.rotation * Quaternion.Euler(0,valor,0);
        //Quaternion quat = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,100,100), 0.01f);
        //transform.rotation = quat;

        switch (ejercicio)
        {
            case Funciones.Uno:
                Vector3Debugger.EnableEditorView("primero");
                Vector3Debugger.DisableEditorView("segundo");
                Vector3Debugger.DisableEditorView("tercero");

                // ---------------

                MyQuatern miQuat1 = MyQuatern.Euler(0, valor, 0);

                ejer1 = (miQuat1 * new Vec3(ejer1));

                // ---------------

                Vector3Debugger.UpdatePosition("primero", ejer1);

                break;

            case Funciones.Dos:
                Vector3Debugger.EnableEditorView("segundo");
                Vector3Debugger.DisableEditorView("primero");
                Vector3Debugger.DisableEditorView("tercero");

                // ---------------

                MyQuatern miQuat2 = MyQuatern.Euler(0, valor, 0);

                ejer2[1] = (miQuat2 * new Vec3(ejer2[1]));
                ejer2[2] = (miQuat2 * new Vec3(ejer2[2]));
                ejer2[3] = (miQuat2 * new Vec3(ejer2[3]));

                // ---------------

                Vector3Debugger.UpdatePositionsSecuence("segundo", ejer2);

                break;

            case Funciones.Tres:
                Vector3Debugger.EnableEditorView("tercero");
                Vector3Debugger.DisableEditorView("primero");
                Vector3Debugger.DisableEditorView("segundo");

                // ---------------

                MyQuatern miQuat3 = MyQuatern.Euler(valor * 1.5f, valor * 1.5f, 0);

                ejer3[1] = (miQuat3 * new Vec3(ejer3[1]));
                ejer3[3] = (MyQuatern.Inverse(miQuat3) * new Vec3(ejer3[3]));

                // ---------------

                Vector3Debugger.UpdatePositionsSecuence("tercero", ejer3);

                break;
        }
        
    }
}