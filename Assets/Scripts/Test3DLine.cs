using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;
using TMPro;
public class Test3DLine : MonoBehaviour
{
    public Material MaterialPlane;
    public float Lenght;
    public GameObject CameraMain;
    public int segments;
    public int numberOfLines;
    private float distanceBetweenLines;
    public bool doLoop = true;
    public Texture2D lineTex;
    public Texture2D frontTex;
    public float lineWidth = 2.0f;
    public Slider A_Slider;
    public Slider B_slider;
    public Slider C_slider;
    public Slider Number_Slider;
    public TextMeshPro MeshPro;
    List<Vector3> splinePoints;
    List<Vector3> gridPoints;
    List<Vector3> XOY_Points;
    VectorLine Grid;
    VectorLine XOY_Line;
    VectorLine Spline;
    Color colorSpline;
    Color colorGrid;
    Color colorXOY;
    float A;
    float B;
    float C;
    float index = 0;
    // Start is called before the first frame update
    void Start()
    {
        distanceBetweenLines = Lenght / (2 * numberOfLines);
        A = 1;
        B = 0;
        C = 0;
        // // A_Slider.value = A;
        // // B_slider.value = B;
        // // C_slider.value = C;
        // Number_Slider.value = numberOfLines;
        gridPoints = new List<Vector3>();
        splinePoints = new List<Vector3>();
        XOY_Points = new List<Vector3>();
        colorGrid = Color.white;
        colorSpline = Color.red;
        colorXOY = Color.white;
        //VectorLine.SetCamera3D(CameraMain);
        VectorLine.SetEndCap("arrow", EndCap.Both, 0, -3, -3, 3, lineTex, frontTex, frontTex);

        Grid = new VectorLine("Grid", gridPoints, lineWidth * distanceBetweenLines);
        XOY_Line = new VectorLine("XOY_Line", XOY_Points, 8 * lineWidth * distanceBetweenLines);
        Spline = new VectorLine("Spline", splinePoints, 10 * lineWidth * distanceBetweenLines, LineType.Continuous);
        CreateGridList();
        Created_XOY_Line();
        CreatedSplineList();
        //Grid.Draw3D();
        //XOY_Line.Draw3D();
        //Spline.Draw3D();
        //SetDraw();
         SetColorWhite();
        var grid = GameObject.Find("Grid");
        var graph = GameObject.Find("Spline");
        var xoy = GameObject.Find("XOY_Line");

        var controller = GameObject.Find("Controller");
        grid.transform.parent = controller.transform;
        graph.transform.parent = controller.transform;
        graph.transform.localPosition = new Vector3(0, 0, -0.015f);
        xoy.transform.parent = controller.transform;
        xoy.transform.localPosition = new Vector3(0, 0, -0.01f);
        grid.transform.localPosition = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDraw()
    {
        string equal = "y=";
        if (A != 1)
        {
            equal += A.ToString();
        }

        if (B != 0)
        {
            if (B > 0)
            {
                equal += "(x+" + B.ToString() + ")" + "<sup>2</sup>";
            }
            else
            {
                equal += "(x" + B.ToString() + ")" + "<sup>2</sup>";
            }

        }
        else
        {
            equal += "x<sup>2</sup>";
        }
        if (C != 0)
        {
            if (C > 0)
            {
                equal += "+" + C.ToString();
            }
            else
            {
                equal += C.ToString();
            }

        }
        if (A == 0)
        {

            if (C > 0)
            {
                equal = "y=" + C.ToString();
            }
            else
            {
                equal = "y=" + C.ToString();
            }


        }
        MeshPro.SetText(equal);
        Grid.SetColor(colorGrid);
        Grid.Draw3D();

        XOY_Line.SetColor(colorXOY);
        XOY_Line.endCap = "arrow";
        XOY_Line.Draw3D();

       // Spline.joins = Joins.Fill;
        Spline.SetColor(colorSpline);
        Spline.endCap = "arrow";

        Spline.Draw3D();


    }
    public void CreatedSplineList()
    {
        splinePoints.Clear();
        for (float i = -numberOfLines; i <= numberOfLines; i += 0.01f)
        {
            //Debug.Log(index);
            // spline.points3[index] = new Vector3(i, i * i, 0);
            //index++;
            if (A * Mathf.Pow((i + B), 2) + C <= numberOfLines && A * Mathf.Pow((i + B), 2) + C >= -numberOfLines)
            {
                splinePoints.Add(new Vector3(i * distanceBetweenLines, (A * Mathf.Pow((i + B), 2) + C) * distanceBetweenLines, 0));
            }
        }
    }
    public void Created_XOY_Line()
    {
        XOY_Points.Clear();
        XOY_Points.Add(new Vector3(-(numberOfLines * distanceBetweenLines), 0, 0));
        XOY_Points.Add(new Vector3((numberOfLines * distanceBetweenLines), 0, 0));
        XOY_Points.Add(new Vector3(0, -(numberOfLines * distanceBetweenLines), 0));
        XOY_Points.Add(new Vector3(0, (numberOfLines * distanceBetweenLines), 0));


    }
    public void CreateGridList()
    {
        gridPoints.Clear();
        // Lines down X axis
        for (int i = -numberOfLines; i <= numberOfLines; i++)
        {
            if (i != 0)
            {
                gridPoints.Add(new Vector3(i * distanceBetweenLines, -((numberOfLines) * distanceBetweenLines), 0));
                gridPoints.Add(new Vector3(i * distanceBetweenLines, (numberOfLines) * distanceBetweenLines, 0));
            }

        }
        // Lines down Z axis
        for (int i = -numberOfLines; i <= numberOfLines; i++)
        {
            if (i != 0)
            {
                gridPoints.Add(new Vector3(-((numberOfLines) * distanceBetweenLines), i * distanceBetweenLines, 0));
                gridPoints.Add(new Vector3((numberOfLines) * distanceBetweenLines, i * distanceBetweenLines, 0));
            }

        }
    }
    public void SetOffset()
    {
        //spline.textureOffset = index;
        Spline.SetColor(Color.red);
        // spline.joins = Joins.Weld;
        Spline.Draw3D();
        // index += 0.25f;
    }
    public void SetKoef(float value)
    {
        Spline.points3.Clear();
        splinePoints.Clear();

        for (float i = -50; i <= 50; i += 0.1f)
        {
            if (i == 0)
            {
                splinePoints.Add(new Vector3(i, value / 0.00000000000000000000000000000000000000001f, 0));
            }
            else
            {
                splinePoints.Add(new Vector3(i, value / i, 0));
            }

        }

        Spline.points3 = splinePoints;
        //spline = new VectorLine("Spline", new List<Vector3>(segments + 1), 6.0f, LineType.Continuous);
        //spline.MakeSpline(splinePoints.ToArray(), segments, doLoop);
        Spline.SetColor(Color.red);
        Spline.Draw3D();
    }
    public void SetNubberOflines(float numberLine)
    {
        Debug.Log(numberLine);
        numberOfLines = (int)numberLine;
        distanceBetweenLines = Lenght / (2 * numberOfLines);
        CreateGridList();
        Created_XOY_Line();
        CreatedSplineList();
        SetDraw();
    }
    public void Set_A(float a)
    {
        A = (float)System.Math.Round(a, 1);
        CreatedSplineList();
        SetDraw();
    }
    public void Set_B(float b)
    {
        B = b;
        CreatedSplineList();
        SetDraw();
    }
    public void Set_C(float c)
    {
        C = c;
        CreatedSplineList();
        SetDraw();
    }
    public void SetColorGreen()
    {
        MaterialPlane.SetColor("_Color", Color.green);
        colorGrid = Color.white;
        colorXOY = Color.white;
        SetDraw();
    }
    public void SetColorWhite()
    {
        MaterialPlane.SetColor("_Color", Color.white);
        colorGrid = Color.black;
        colorXOY = Color.black;
        SetDraw();
    }
}
