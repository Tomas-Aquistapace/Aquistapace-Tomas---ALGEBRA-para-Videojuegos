using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;

public class PlanesTarea : MonoBehaviour
{
    public Transform cube;

    Vec3 frontA = new Vec3(2,-2,-2);
    Vec3 frontB = new Vec3(2,2,2);
    Vec3 backA = new Vec3(-2,-2,-2);
    Vec3 backB = new Vec3(-2,2,2);
    Vec3 STop = new Vec3(2,2,-2);
    Vec3 SDown = new Vec3(2,-2,2);

    Plane planeFront;
    Plane planeRight;
    Plane planeLeft;
    Plane planeDown;
    Plane planeTop;
    Plane planeBack;

    void Start()
    {
        planeFront = new Plane(frontA, frontB);
        planeRight = new Plane(SDown, backB);
        planeLeft = new Plane(STop, backA);
        planeDown = new Plane(backA, SDown);
        planeTop = new Plane(STop, backB);
        planeBack = new Plane(backA, backB);
    }

    void Update()
    {
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
        }
    }

    bool DetectVertexCube(Transform cube)
    {
        int VERTEX_CANT = 8;
        int cont = 0;
        List<Vec3> cubeVert = new List<Vec3>();

        List<GameObject> cub = new List<GameObject>();

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
                //Debug.Log("Esta adentro");
                //Debug.Log("Este - " + cub[i].transform.position);
            }
            else
            {
                //Debug.Log("Esta afuera");
                cont++;
            }

            cub.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            cub[i].transform.position = cubeVert[i];
            cub[i].transform.localScale = new Vec3(0.1f, 0.1f, 0.1f);
            cub[i].name = i.ToString();

            //Debug.Log("Pos: " + i + " - " + cubeVert[i]);
        }

        // Si todos estan afuera, ahi sale que es falso, sino, sale verdadero
        if (cont <= VERTEX_CANT - 1)
            return true;
        else
            return false;
    }
}
