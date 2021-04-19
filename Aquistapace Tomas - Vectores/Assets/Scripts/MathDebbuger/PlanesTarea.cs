using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

public class PlanesTarea : MonoBehaviour
{
    public Transform cube;

    //public Vector3 VfrontA = new Vec3(2, -2, -2);
    //public Vector3 VfrontB = new Vec3(2, 2, 2);
    //public Vector3 VbackA = new Vec3(-2, -2, -2);
    //public Vector3 VbackB = new Vec3(-2, 2, 2);
    //public Vector3 VSTop = new Vec3(2, 2, -2);
    //public Vector3 VSDown = new Vec3(2, -2, 2);

    public Vector3 FrontSupRight;
    public Vector3 FrontSupLeft;
    public Vector3 FrontInfRight;
    public Vector3 FrontInfLeft;
    public Vector3 BackSupRight;
    public Vector3 BackSupLeft;
    public Vector3 BackInfRight;
    public Vector3 BackInfLeft;

    //Vec3 frontA;
    //Vec3 frontB;
    //Vec3 backA;
    //Vec3 backB;
    //Vec3 STop;
    //Vec3 SDown;

    Vec3 frontSR;
    Vec3 frontSL;
    Vec3 frontIR;
    Vec3 frontIL;
    Vec3 BackSR;
    Vec3 BackSL;
    Vec3 BackIR;
    Vec3 BackIL;

    Plane planeFront;
    Plane planeRight;
    Plane planeLeft;
    Plane planeDown;
    Plane planeTop;
    Plane planeBack;

    void Start()
    {
        //frontA = new Vec3(VfrontA);
        //frontB = new Vec3(VfrontB);
        //backA = new Vec3(VbackA);
        //backB = new Vec3(VbackB);
        //STop = new Vec3(VSTop);
        //SDown = new Vec3(VSDown);

        frontSR = new Vec3(FrontSupRight);
        frontSL = new Vec3(FrontSupLeft);
        frontIR = new Vec3(FrontInfRight);
        frontIL = new Vec3(FrontInfLeft);
        BackSR = new Vec3(BackSupRight);
        BackSL = new Vec3(BackSupLeft);
        BackIR = new Vec3(BackInfRight);
        BackIL = new Vec3(BackInfLeft);

        //planeFront = new Plane(frontA, frontB);
        //planeRight = new Plane(SDown, backB);
        //planeLeft = new Plane(STop, backA);
        //planeDown = new Plane(backA, SDown);
        //planeTop = new Plane(STop, backB);
        //planeBack = new Plane(backA, backB);

        planeFront = new Plane(FrontInfLeft, FrontSupRight);
        planeBack = new Plane(BackInfLeft, BackSupRight);
        planeRight = new Plane(BackSupRight, FrontInfRight);
        planeLeft = new Plane(BackSupLeft, FrontInfLeft);
        planeTop = new Plane(BackSupRight, FrontSupLeft);
        planeDown = new Plane(BackInfLeft, FrontInfRight);
    }

    void Update()
    {
        // Las lineas para ver el Frustrum en el debugger
        Debug.DrawLine(FrontInfLeft, FrontSupLeft, Color.green);
        Debug.DrawLine(FrontInfLeft, FrontInfRight, Color.green);
        Debug.DrawLine(FrontInfLeft, BackInfLeft, Color.green);

        Debug.DrawLine(FrontSupRight, BackSupRight, Color.green);
        Debug.DrawLine(FrontSupRight, FrontInfRight, Color.green);
        Debug.DrawLine(FrontSupRight, FrontSupLeft, Color.green);

        Debug.DrawLine(BackSupLeft, BackSupRight, Color.green);
        Debug.DrawLine(BackSupLeft, BackInfLeft, Color.green);
        Debug.DrawLine(BackSupLeft, FrontSupLeft, Color.green);

        Debug.DrawLine(BackInfRight, FrontInfRight, Color.green);
        Debug.DrawLine(BackInfRight, BackSupRight, Color.green);
        Debug.DrawLine(BackInfRight, BackInfLeft, Color.green);
        // ---------------------------------------------------

        // Las lineas para ver los planos
        Debug.DrawLine(FrontInfLeft, FrontSupRight, Color.blue);  //planeFront
        Debug.DrawLine(BackSupRight, BackInfLeft, Color.blue);    //planeBack 
        Debug.DrawLine(FrontInfRight, BackSupRight, Color.black); //planeRight
        Debug.DrawLine(FrontInfLeft, BackSupLeft, Color.black);   //planeLeft 
        Debug.DrawLine(FrontSupLeft, BackSupRight, Color.red);    //planeTop
        Debug.DrawLine(BackInfLeft, FrontInfRight, Color.red);    //planeDown 
        // ---------------------------------------------------

        /*
        if (Input.GetKeyDown("space"))
        {
            if (DetectVertexCube(cube))
            {
                Debug.Log("adentro");
            }
            else
            {
                Debug.Log("afuera");
            }
        }*/

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

    bool DetectVertexCube(Transform cube)
    {
        int VERTEX_CANT = 8;
        int cont = 0;
        List<Vec3> cubeVert = new List<Vec3>();

        // Crea una lista de objetos cubos para debugear
        //List<GameObject> cub = new List<GameObject>();

        cubeVert.Add(new Vec3(cube.position.x + cube.localScale.x / 2, cube.position.y - cube.localScale.y / 2, cube.position.z - cube.localScale.z / 2));// Front - Izq - Infer
        cubeVert.Add(new Vec3(cube.position.x + cube.localScale.x / 2, cube.position.y - cube.localScale.y / 2, cube.position.z + cube.localScale.z / 2));// Front - Der - Infer
        cubeVert.Add(new Vec3(cube.position.x + cube.localScale.x / 2, cube.position.y + cube.localScale.y / 2, cube.position.z - cube.localScale.z / 2));// Front - Izq - Sup
        cubeVert.Add(new Vec3(cube.position.x + cube.localScale.x / 2, cube.position.y + cube.localScale.y / 2, cube.position.z + cube.localScale.z / 2));// Front - Der - Sup
        cubeVert.Add(new Vec3(cube.position.x - cube.localScale.x / 2, cube.position.y - cube.localScale.y / 2, cube.position.z - cube.localScale.z / 2));// Tras - Izq - Inf
        cubeVert.Add(new Vec3(cube.position.x - cube.localScale.x / 2, cube.position.y - cube.localScale.y / 2, cube.position.z + cube.localScale.z / 2));// Tras - Der - Inf
        cubeVert.Add(new Vec3(cube.position.x - cube.localScale.x / 2, cube.position.y + cube.localScale.y / 2, cube.position.z - cube.localScale.z / 2));// Tras - Izq - Sup
        cubeVert.Add(new Vec3(cube.position.x - cube.localScale.x / 2, cube.position.y + cube.localScale.y / 2, cube.position.z + cube.localScale.z / 2));// Tras - Der - Sup

        for (int i = 0; i < VERTEX_CANT; i++)
        {
            if (planeFront.GetSide(cubeVert[i]) && planeRight.GetSide(cubeVert[i]) && planeLeft.GetSide(cubeVert[i]) &&
             planeDown.GetSide(cubeVert[i]) && planeTop.GetSide(cubeVert[i]) && planeBack.GetSide(cubeVert[i]))
            {

            }
            else
            {
                cont++;
            }

            // Crea una lista de objetos cubos para debugear
            //cub.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            //cub[i].transform.position = cubeVert[i];
            //cub[i].transform.localScale = new Vec3(0.1f, 0.1f, 0.1f);
            //cub[i].name = i.ToString();
        }
        Debug.Log(cont);
        // Si todos estan afuera, ahi sale que es falso, sino, sale verdadero
        if (cont <= VERTEX_CANT - 1)
            return true;
        else
            return false;
    }

    bool DetectObject(Transform cube)
    {
        Debug.Log("Front: " + planeFront.GetSide(cube.transform.position));
        Debug.Log("Right: " + planeRight.GetSide(cube.transform.position));
        Debug.Log("Left: " + planeLeft.GetSide(cube.transform.position));
        Debug.Log("Down: " + planeDown.GetSide(cube.transform.position));
        Debug.Log("Top: " + planeTop.GetSide(cube.transform.position));
        Debug.Log("Back: " + planeBack.GetSide(cube.transform.position));


        if (planeFront.GetSide(cube.transform.position) && planeRight.GetSide(cube.transform.position) && planeLeft.GetSide(cube.transform.position) &&
             planeDown.GetSide(cube.transform.position) && planeTop.GetSide(cube.transform.position) && planeBack.GetSide(cube.transform.position))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
