using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
public class Tester : MonoBehaviour
{
    public enum Funciones {
        Cross, Lerp, LerpUnclamped, Max, Mix, Project, Reflect
    }

    public Funciones funcion;
    public Color colorVec;

    public Vector3 ejerA;
    public Vector3 ejerB;
    [HideInInspector]
    public Vector3 resultado;

    void Start()
    {
        //List<Vector3> vectors = new List<Vector3>();
        //vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        //vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        //vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        //vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        //Vector3Debugger.AddVectorsSecuence(vectors, false, Color.red, "secuencia");
        //Vector3Debugger.EnableEditorView("secuencia");
        //Vector3Debugger.AddVector(new Vector3(10, 10, 0), Color.blue, "elAzul");
        //Vector3Debugger.EnableEditorView("elAzul");
        //Vector3Debugger.AddVector(Vector3.down * 7, Color.green, "elVerde");
        //Vector3Debugger.EnableEditorView("elVerde");

        Vector3Debugger.AddVector(resultado, colorVec, "elResultado");
        Vector3Debugger.EnableEditorView("elBlanco");
        Vector3Debugger.AddVector(ejerA, Color.black, "elNegro");
        Vector3Debugger.EnableEditorView("elNegro");
        Vector3Debugger.AddVector(ejerB, Color.white, "elBlanco");
        Vector3Debugger.EnableEditorView("elAmarillo");

        // ------ Angle FUNCIONA
        // ------ Magnitud FUNCIONA
        // ------ Producto Punto / Dot FUNCIONA
        // ------ Distance FUNCIONA
        // ------ Cross FUNCIONA
        // ------ Min FUNCIONA
        // ------ Max FUNCIONA
        // ------ Normalize FUNCIONA ----- Mas o menos
        // ------ ClamMagniude FUNCIONA ----- Mas o menos
        // ------ Set FUNCIONA
        // ------ Scale FUNCIONA
        // ------ Project FUNCIONA
        // ------ Lerp FUNCIONA
        // ------ LerpUpClamped FUNCIONA

        //Vector3 unity1 = new Vector3(7,-1,5);
        //Vector3 unity2 = new Vector3(-13,8,9);
        //Vec3    prueb1 = new    Vec3(7,-1,5);
        //Vec3    prueb2 = new    Vec3(-13,8,9);

        //Vector3 uni = Vector3.Min(unity1, unity2);
        //Vec3 prop = Vec3.Min(prueb1, prueb2);

        //Debug.Log("Vector Normal: " + unity1);
        //unity1.Scale(unity2);
        //Debug.Log("Vector nuevo: " + Vector3.Reflect(unity1, unity2));
        //Debug.Log("-----------------");
        //Debug.Log("Vector Normal: " + prueb1);
        //prueb1.Scale(prueb2);
        //Debug.Log("Vector Nuevo: " + Vec3.Reflect(prueb1, prueb2));
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine( UpdateBlueVector());
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Vector3Debugger.TurnOffVector("elAzul");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3Debugger.TurnOnVector("elAzul");
        }

        Vec3 A = new Vec3(ejerA);
        Vec3 B = new Vec3(ejerB);

        switch (funcion)
        {
            case Funciones.Cross:

                break;

            case Funciones.Lerp:

                break;

            case Funciones.LerpUnclamped:

                break;

            case Funciones.Max:

                break;

            case Funciones.Mix:

                break;

            case Funciones.Project:

                break;

            case Funciones.Reflect:

                break;
        }

        //resultado = Vector3.Reflect(ejerA, ejerB);
        //
        //Vector3Debugger.UpdatePosition("elBlanco", resultado);
        //Vector3Debugger.UpdatePosition("elNegro", ejerA);
        //Vector3Debugger.UpdatePosition("elAmarillo", ejerB);
    }

    IEnumerator UpdateBlueVector()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3Debugger.UpdatePosition("elAzul", new Vector3(2.4f, 6.3f, 0.5f) * (i * 0.05f));
            yield return new WaitForSeconds(0.2f);
        }
    }

}
