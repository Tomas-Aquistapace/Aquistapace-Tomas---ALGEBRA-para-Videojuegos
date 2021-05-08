using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
public class Tester : MonoBehaviour
{
    public enum Funciones {
        Uno, Dos, Tres, Cuatro, Cinco, Seis, Siete, Ocho, Nueve, Diez
    }

    public Funciones funcion;
    public Color colorVec;

    public Vector3 ejerA = Vector3.zero;
    public Vector3 ejerB = Vector3.zero;
    [HideInInspector]
    public Vector3 resultado = Vector3.zero;

    void Start()
    {
        Vector3Debugger.AddVector(resultado, colorVec, "elResultado");
        Vector3Debugger.EnableEditorView("elResultado");
        Vector3Debugger.AddVector(ejerA, Color.black, "elNegro");
        Vector3Debugger.EnableEditorView("elNegro");
        Vector3Debugger.AddVector(ejerB, Color.white, "elBlanco");
        Vector3Debugger.EnableEditorView("elBlanco");

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
    }
    
    void Update()
    {
        Vec3 A = new Vec3(ejerA);
        Vec3 B = new Vec3(ejerB);
        Vec3 C = new Vec3(resultado);

        switch (funcion)
        {
            case Funciones.Uno: // Suma de Dos Vectores3

                C = A + B;

                break;

            case Funciones.Dos: // Resta de dos Vectores3

                C = A - B;

                break;

            case Funciones.Tres: // Se hace una escala entre los dos Vectores Existentes

                C = A;
                C.Scale(B);

                break;

            case Funciones.Cuatro:

                C = Vec3.Cross(A, B);

                break;

            case Funciones.Cinco:

                // Lerp

                break;

            case Funciones.Seis:

                // Max

                break;

            case Funciones.Siete:

                // Proyect

                break;

            case Funciones.Ocho:

                Vec3 suma = A + B;
                C = suma.normalized * Vec3.Distance(A, B);

                break;

            case Funciones.Nueve:

                // Reflect

                break;

            case Funciones.Diez:

                // LerpUnclamp

                break;
        }

        //resultado = Vector3.Reflect(ejerA, ejerB);
        //
        Vector3Debugger.UpdatePosition("elBlanco", resultado);
        Vector3Debugger.UpdatePosition("elNegro", ejerA);
        Vector3Debugger.UpdatePosition("elAmarillo", ejerB);
    }

    //IEnumerator UpdateBlueVector()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Vector3Debugger.UpdatePosition("elAzul", new Vector3(2.4f, 6.3f, 0.5f) * (i * 0.05f));
    //        yield return new WaitForSeconds(0.2f);
    //    }
    //}
}
