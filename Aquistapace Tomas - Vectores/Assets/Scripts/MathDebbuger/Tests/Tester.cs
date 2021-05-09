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

    float timeLerp;
    float timeLerpUnclamp;

    void Start()
    {
        Vector3Debugger.AddVector(resultado, colorVec, "elResultado");
        Vector3Debugger.EnableEditorView("elResultado");
        Vector3Debugger.AddVector(ejerA, Color.black, "elNegro");
        Vector3Debugger.EnableEditorView("elNegro");
        Vector3Debugger.AddVector(ejerB, Color.white, "elBlanco");
        Vector3Debugger.EnableEditorView("elBlanco");

        timeLerp = 0;
        timeLerpUnclamp = 1;
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

                C = B - A;

                break;

            case Funciones.Tres: // Se hace una escala entre los dos Vectores Existentes

                C = A;
                C.Scale(B);

                break;

            case Funciones.Cuatro: // Se hace un producto Cruz entre los dos vectores

                C = Vec3.Cross(B, A);

                break;

            case Funciones.Cinco: // Se hace un Lerp entre los dos vectores

                if (timeLerp > 1)
                    timeLerp = 0;
                else
                    timeLerp += Time.deltaTime;

                C = Vec3.Lerp(A, B, timeLerp);

                break;

            case Funciones.Seis: // Se hace se saca los valores maximos de cada vector

                C = Vec3.Max(A, B);

                break;

            case Funciones.Siete: // Se saca la Proyeccion entre dos vectores
                
                C = Vec3.Project(A, B);

                break;

            case Funciones.Ocho: // Se hace un normalize de los dos vectores y despues se multiplica a la distancia entre los mismos                            Pdt. Este costo porque era raro

                Vec3 suma = A + B;
                C = suma.normalized * Vec3.Distance(A, B);

                break;

            case Funciones.Nueve: // Se hace un reflect utilizando los los vertores
                
                C = Vec3.Reflect(B, A);

                break;

            case Funciones.Diez: // Se hace un LerpUnclamped para que no se detenga cuando llega al limite permitido y asi siga avanzando

                timeLerpUnclamp -= Time.deltaTime;

                C = Vec3.LerpUnclamped(A, B, timeLerpUnclamp);

                break;
        }
        ejerA = A;
        ejerB = B;
        resultado = C;

        Vector3Debugger.UpdatePosition("elResultado", resultado);
        Vector3Debugger.UpdatePosition("elNegro", ejerA);
        Vector3Debugger.UpdatePosition("elBlanco", ejerB);
    }
}
