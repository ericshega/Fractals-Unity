using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class GeneratFractals : MonoBehaviour
{
    public static int iterations;
    public static int Fractals;
    public static float size;
    public static int max_Iterations;

    public float initialLength;
    public float initialRadius;
    public float lineWidth;
    public float scale;

    public int recursionDepth;
    public int segments;   
    public int current_Iterationsh;

    public Material lineMaterial;
    public Material triangleMaterial;
    public Material squareMaterial;
    public Material circleMaterial;   

    public Camera Camera_values;

    public GameObject cubePrefab;    
    public GameObject Quad_GameObject;
    public GameObject UpIterations_Fractal7_GO;
    public GameObject DownIterations_Fractal7_GO;
    public GameObject UpIterations_Fractal_GO;
    public GameObject DownIterations_Fractal_GO;   

    public MandelbrotSet MandelbrotSet_refrence;

    void Start()
    {

        MandelbrotSet_refrence = FindAnyObjectByType<MandelbrotSet>();

        UpIterations_Fractal7_GO = GameObject.Find("UpIterations_Fractal7");
        DownIterations_Fractal7_GO = GameObject.Find("DownIterations_Fractal7");

        UpIterations_Fractal_GO = GameObject.Find("UpIterations");
        DownIterations_Fractal_GO = GameObject.Find("DownIterations");

        initialLength = 10f;
        initialRadius = 5f;
        recursionDepth = 5;
        segments = 100;
        lineWidth = 0.1f;
        current_Iterationsh = 1;
        scale = 1.0f;

        if (Fractals == 0)
        {
            RecursiveOneCircles(transform.position, initialRadius, recursionDepth);

            Camera_values.transform.position = new Vector3(0f,0f,-11f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 1)
        {
            Vector3 center = transform.position;
            RecursiveCircles(center, initialRadius, iterations);

            Camera_values.transform.position = new Vector3(0f, 0f, -11f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 2)
        {
            Vector3 p1 = new Vector3(0, 0, 0);
            Vector3 p2 = new Vector3(size, 0, 0);
            Vector3 p3 = new Vector3(size / 2f, Mathf.Sqrt(3) * size / 2f, 0);
            SierpinskiGasket(p1, p2, p3, iterations);

            Camera_values.transform.position = new Vector3(2f, 1f, 11f);
            Camera_values.transform.rotation = Quaternion.Euler(-180f, 0f, 0f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 3)
        {
            Vector3 center = new Vector3(0, 0, 0);
            SierpinskiCarpet(center, size, iterations);

            Camera_values.transform.position = new Vector3(0f, 0f, -11f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 4)
        {
            Vector3 p1 = new Vector3(0, 0, 0);
            Vector3 p2 = new Vector3(initialLength, 0, 0);
            KochSnowflake(p1, p2, iterations);

            Camera_values.transform.position = new Vector3(5f, 0f, -11f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 5)
        {
            CreateSierpinskiCarpet_3D(Vector3.zero, scale, current_Iterationsh);

            Camera_values.transform.position = new Vector3(0f, 0f, -2f);

            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(false);

            UpIterations_Fractal7_GO.SetActive(false);
            DownIterations_Fractal7_GO.SetActive(false);

            UpIterations_Fractal_GO.SetActive(true);
            DownIterations_Fractal_GO.SetActive(true);
        }

        if (Fractals == 6)
        {
            Quad_GameObject = GameObject.Find("Quad");
            Quad_GameObject.SetActive(true);

            UpIterations_Fractal7_GO.SetActive(true);
            DownIterations_Fractal7_GO.SetActive(true);

            UpIterations_Fractal_GO.SetActive(false);
            DownIterations_Fractal_GO.SetActive(false);
        }


        Debug.Log(max_Iterations);

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            //RecursiveCircles One circle
            Fractals = 0;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            //Recursive Circles
            Fractals = 1;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F3))
        {
            //Sierpinski Gasket
            Fractals = 2;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F4))
        {
            //Sierpinski Carpet
            Fractals = 3;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F5))
        {
            //KochSnow flake
            Fractals = 4;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F6))
        {
            //Sierpinski Carpet in 3D
            Fractals = 5;
            SceneManager.LoadScene("Fractals");
        }

        if (Input.GetKeyUp(KeyCode.F7))
        {
            //MandelbrotSet
            Fractals = 6;
            SceneManager.LoadScene("Fractals");
        }

        if (Fractals == 5)
        {
            CreateSierpinskiCarpet_Update_Refrence();
        }

        Debug.Log(iterations);
    }

    public void Fractal1()
    {
        //RecursiveCircles One circle
        Fractals = 0;
        SceneManager.LoadScene("Fractals");
    }

    public void Fractal2()
    {
        //Recursive Circles
        Fractals = 1;
        SceneManager.LoadScene("Fractals");
    }

    public void Fractal3()
    {
        //Sierpinski Gasket
        Fractals = 2;
        SceneManager.LoadScene("Fractals");
    }

    public void Fractal4()
    {
        //Sierpinski Carpet
        Fractals = 3;
        SceneManager.LoadScene("Fractals");
    }

    public void Fractal5()
    {
        //KochSnow flake
        Fractals = 4;
        SceneManager.LoadScene("Fractals");
    }
    public void Fractal6()
    {
        //Sierpinski Carpet in 3D
        Fractals = 5;
        SceneManager.LoadScene("Fractals");
    }

    public void Fractal7()
    {
        //MandelbrotSet
        Fractals = 6;
        SceneManager.LoadScene("Fractals");
    }

    public void Increse_Iterations()
    {
        if (Fractals == 1 || Fractals == 2 || Fractals == 3 || Fractals == 4)
        { 
            iterations++;
            SceneManager.LoadScene("Fractals");
        }

        if (Fractals == 5)
        {
            max_Iterations++;
            SceneManager.LoadScene("Fractals");
        }

    }

    public void Decrease_Iterations()
    {
        if (Fractals == 1 || Fractals == 2 || Fractals == 3 || Fractals == 4)
        {
            iterations--;
            SceneManager.LoadScene("Fractals");
        }

        if (Fractals == 5)
        {
            max_Iterations--;
            SceneManager.LoadScene("Fractals");
        }
    }

    public void Increse_Size()
    {
        size++;
        SceneManager.LoadScene("Fractals");
    }

    public void Decrease_Size()
    {
        size--;
        SceneManager.LoadScene("Fractals");
    }

    void CreateSierpinskiCarpet_Update_Refrence()
    {
        if (current_Iterationsh < max_Iterations)
        {
            current_Iterationsh++;
            CreateSierpinskiCarpet_3D(Vector3.zero, scale, current_Iterationsh);
        }
    }

    void CreateSierpinskiCarpet_3D(Vector3 position, float size, int depth)
    {
        if (depth <= 0)
        {
            return;
        }

        float newSize = size / 3.0f;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    if (Mathf.Abs(x) != 1 || Mathf.Abs(y) != 1 || Mathf.Abs(z) != 1)
                    {
                        Vector3 offset = new Vector3(x * newSize, y * newSize, z * newSize);
                        CreateSierpinskiCarpet_3D(position + offset, newSize, depth - 1);
                    }
                }
            }
        }

        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
        cube.transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    void RecursiveOneCircles(Vector3 center, float radius, int depth)
    {
        DrawRecursiveOneCircles(center, radius);

        if (depth > 0)
        {
            float newRadius = radius * 0.5f;

            Vector3 offset = Vector3.zero;

            RecursiveOneCircles(center + offset, newRadius, depth - 1);
        }
    }

    void DrawRecursiveOneCircles(Vector3 center, float radius)
    {
        GameObject circle = new GameObject("Circle");
        LineRenderer lineRenderer = circle.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float theta = 2f * Mathf.PI * i / segments;
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);

            Vector3 point = center + new Vector3(x, y, 0f);
            lineRenderer.SetPosition(i, point);
        }

        circle.transform.SetParent(transform);
    }

    void RecursiveCircles(Vector3 center, float radius, int iteration)
    {
        if (iteration == 0)
        {
            RecursiveCirclesCreateCircle(center, radius);
        }
        else
        {
            RecursiveCirclesCreateCircle(center, radius);

            float newRadius = radius / 2f;

            for (int i = 0; i < 6; i++)
            {
                float angle = i * (Mathf.PI / 3f);
                Vector3 position = center + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

                RecursiveCircles(position, newRadius, iteration - 1);
            }
        }
    }

    void RecursiveCirclesCreateCircle(Vector3 center, float radius)
    {
        GameObject circle = new GameObject("RecursiveCircle");
        LineRenderer lineRenderer = circle.AddComponent<LineRenderer>();
        lineRenderer.material = circleMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        int segments = 50;
        lineRenderer.positionCount = segments + 1;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * (2 * Mathf.PI / segments);
            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius;
            lineRenderer.SetPosition(i, new Vector3(x, y, center.z));
        }
    }

    void SierpinskiCarpet(Vector3 center, float size, int iteration)
    {
        if (iteration == 0)
        {
            SierpinskiCarpetCreateSquare(center, size);
        }
        else
        {
            float newSize = size / 3f;

            Vector3[] positions =
            {
                center + new Vector3(-newSize, newSize, 0),
                center + new Vector3(0, newSize, 0),
                center + new Vector3(newSize, newSize, 0),
                center + new Vector3(-newSize, 0, 0),
                center + new Vector3(newSize, 0, 0),
                center + new Vector3(-newSize, -newSize, 0),
                center + new Vector3(0, -newSize, 0),
                center + new Vector3(newSize, -newSize, 0),
            };

            foreach (var position in positions)
            {
                SierpinskiCarpet(position, newSize, iteration - 1);
            }
        }
    }

    void SierpinskiCarpetCreateSquare(Vector3 center, float size)
    {
        GameObject square = new GameObject("SierpinskiCarpetSquare");
        MeshFilter meshFilter = square.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = square.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        float halfSize = size / 2f;
        mesh.vertices = new Vector3[]
        {
            center + new Vector3(-halfSize, halfSize, 0),
            center + new Vector3(halfSize, halfSize, 0),
            center + new Vector3(halfSize, -halfSize, 0),
            center + new Vector3(-halfSize, -halfSize, 0),
        };
        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        meshFilter.mesh = mesh;
        meshRenderer.material = squareMaterial;
    }

    void SierpinskiGasket(Vector3 p1, Vector3 p2, Vector3 p3, int iteration)
    {
        if (iteration == 0)
        {
            SierpinskiGasketCreateTriangle(p1, p2, p3);
        }
        else
        {
            Vector3 midPoint1 = (p1 + p2) / 2f;
            Vector3 midPoint2 = (p2 + p3) / 2f;
            Vector3 midPoint3 = (p3 + p1) / 2f;

            SierpinskiGasket(p1, midPoint1, midPoint3, iteration - 1);
            SierpinskiGasket(midPoint1, p2, midPoint2, iteration - 1);
            SierpinskiGasket(midPoint3, midPoint2, p3, iteration - 1);
        }
    }

    void SierpinskiGasketCreateTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        GameObject triangle = new GameObject("SierpinskiGasketTriangle");
        MeshFilter meshFilter = triangle.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = triangle.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] { p1, p2, p3 };
        mesh.triangles = new int[] { 0, 1, 2 };

        meshFilter.mesh = mesh;
        meshRenderer.material = triangleMaterial;
    }

    void KochSnowflake(Vector3 start, Vector3 end, int iteration)
    {
        if (iteration == 0)
        {
            KochSnowflakeCreateLine(start, end);
        }
        else
        {
            Vector3 oneThird = start + (end - start) / 3f;
            Vector3 twoThirds = start + 2 * (end - start) / 3f;

            Vector3 trianglePoint = Quaternion.AngleAxis(-60, Vector3.forward) * (twoThirds - oneThird) + oneThird;

            KochSnowflake(start, oneThird, iteration - 1);
            KochSnowflake(oneThird, trianglePoint, iteration - 1);
            KochSnowflake(trianglePoint, twoThirds, iteration - 1);
            KochSnowflake(twoThirds, end, iteration - 1);
        }
    }

    void KochSnowflakeCreateLine(Vector3 start, Vector3 end)
    {
        GameObject line = new GameObject("KochLine");
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
