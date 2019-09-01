using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;
using TMPro;

public class DrawGraph : MonoBehaviour
{
    public Material MaterialPlane;
    public GameObject CameraMain;
    public Texture2D lineTex;
    public Texture2D frontTex;
    public int segments;
    public float Lenght;
    public int numberOfLines;
    private float distanceBetweenLines;
    public float lineWidth = 2.0f;
    public bool doLoop = true;
    VectorLine Grid;
    VectorLine XOY_Line;
    VectorLine Spline_Current;
    VectorLine Spline_Base;
    public List<Vector3> spline_Current_Points;
    List<Vector3> spline_Base_Points;
    List<Vector3> gridPoints;
    List<Vector3> XOY_Points;
    Color colorSpline_Current;
    Color colorSpline_Base;
    Color colorGrid;
    Color colorXOY;
    // Start is called before the first frame update
    void Start()
    {
        CommonData.Lenght = Lenght;
        CommonData.numberOfLines = numberOfLines;

        distanceBetweenLines = Lenght / (2 * numberOfLines);
        CommonData.distanceBetweenLines = distanceBetweenLines;
        CommonData.X_position = gameObject.transform.localPosition.x;
        CommonData.Z_position = gameObject.transform.localPosition.z;
        Debug.Log("x=" + gameObject.transform.localPosition.x + "  z=" + gameObject.transform.localPosition.z);
        CommonData.Scale = gameObject.transform.localScale.x;
        CommonData.Y_Rotate = gameObject.transform.localEulerAngles.y;
        gridPoints = new List<Vector3>();
        XOY_Points = new List<Vector3>();
        spline_Current_Points = new List<Vector3>();
        spline_Base_Points = new List<Vector3>();
        colorGrid = Color.white;
        colorSpline_Current = Color.red;
        colorSpline_Base = Color.blue;
        colorXOY = Color.white;
        VectorLine.SetCamera3D(CameraMain);

        VectorLine.SetEndCap("arrow", EndCap.Both, 0, -3, -3, 3, lineTex, frontTex, frontTex);
        Grid = new VectorLine("Grid", gridPoints, lineWidth * CommonData.distanceBetweenLines);
        XOY_Line = new VectorLine("XOY_Line", XOY_Points, 8 * lineWidth * CommonData.distanceBetweenLines);
        Spline_Base = new VectorLine("Spline_Base", spline_Base_Points, 10 * lineWidth * CommonData.distanceBetweenLines, LineType.Continuous);
        Spline_Current = new VectorLine("Spline_Current", spline_Current_Points, 10 * lineWidth * CommonData.distanceBetweenLines, LineType.Continuous);

        // var graph_current = GameObject.Find("Spline_Current");
        // var graph_base = GameObject.Find("Spline_Base");
        // 
        // var controller = GameObject.Find("Controller");
        //
        // 
        // graph_current.transform.parent = controller.transform;
        // graph_base.transform.parent = controller.transform;
        // 
        //
        // graph_current.transform.localPosition = new Vector3(0, 0, -0.015f);
        // graph_base.transform.localPosition = new Vector3(0, 0, -0.015f);
        
        

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void CreatedSplineCurrent()
    {
       // spline_Current_Points.Clear();
       // Spline_Current.points3.Clear();
       // spline_Current_Points = enterArray;
        Spline_Current.SetColor(colorSpline_Current);
        Spline_Current.endCap = "arrow";
        Spline_Current.Draw3D();
        var splain = GameObject.Find("Spline_Current");
        var controller = GameObject.Find("Controller");
        splain.transform.parent = controller.transform;
        splain.transform.localEulerAngles = new Vector3(0, 0, 0);
        splain.transform.localPosition = new Vector3(0, 0, -0.01f);
        
    }
    public void Created_XOY_Line()
    {
        CommonData.distanceBetweenLines = CommonData.Lenght / (2 * CommonData.numberOfLines);
        XOY_Points.Clear();
        XOY_Points.Add(new Vector3(-(CommonData.numberOfLines * CommonData.distanceBetweenLines), 0, 0));
        XOY_Points.Add(new Vector3((CommonData.numberOfLines * CommonData.distanceBetweenLines), 0, 0));
        XOY_Points.Add(new Vector3(0, -(CommonData.numberOfLines * CommonData.distanceBetweenLines), 0));
        XOY_Points.Add(new Vector3(0, (CommonData.numberOfLines * CommonData.distanceBetweenLines), 0));
        Debug.Log("XOY=" + XOY_Points.Count);


    }
    public void CreateGridList()
    {
        CommonData.distanceBetweenLines = CommonData.Lenght / (2 * CommonData.numberOfLines);
        gridPoints.Clear();
        // Lines down X axis
        for (int i = -CommonData.numberOfLines; i <= CommonData.numberOfLines; i++)
        {
            if (i != 0)
            {
                gridPoints.Add(new Vector3(i * CommonData.distanceBetweenLines, -((CommonData.numberOfLines) * CommonData.distanceBetweenLines), 0));
                gridPoints.Add(new Vector3(i * CommonData.distanceBetweenLines, (CommonData.numberOfLines) * CommonData.distanceBetweenLines, 0));
            }

        }
        // Lines down Z axis
        for (int i = -CommonData.numberOfLines; i <= CommonData.numberOfLines; i++)
        {
            if (i != 0)
            {
                gridPoints.Add(new Vector3(-((CommonData.numberOfLines) * CommonData.distanceBetweenLines), i * CommonData.distanceBetweenLines, 0));
                gridPoints.Add(new Vector3((CommonData.numberOfLines) * CommonData.distanceBetweenLines, i * CommonData.distanceBetweenLines, 0));
            }

        }
    }
    public void SetColorGreen_Grid()
    {
        MaterialPlane.SetColor("_Color", Color.green);
        colorGrid = Color.white;
        colorXOY = Color.white;
        Grid.SetColor(colorGrid);
        Grid.Draw3D();
        XOY_Line.SetColor(colorXOY);
        XOY_Line.endCap = "arrow";
        XOY_Line.Draw3D();
    }
    public void SetColorWhite_Grid()
    {
        MaterialPlane.SetColor("_Color", Color.white);
        colorGrid = Color.black;
        colorXOY = Color.black;
        Grid.SetColor(colorGrid);
        Grid.Draw3D();
        XOY_Line.SetColor(colorXOY);
        XOY_Line.endCap = "arrow";
        XOY_Line.Draw3D();
    }
    public void SetDraw_Grid()
    {
        Grid.SetColor(colorGrid);
        Grid.Draw3D();

        XOY_Line.SetColor(colorXOY);
        XOY_Line.endCap = "arrow";
        XOY_Line.Draw3D();
        var grid = GameObject.Find("Grid");

        var xoy = GameObject.Find("XOY_Line");
        var controller = GameObject.Find("Controller");

        grid.transform.parent = controller.transform;

        xoy.transform.parent = controller.transform;

        xoy.transform.localEulerAngles = new Vector3(0, 0, 0); ;
        grid.transform.localEulerAngles = new Vector3(0, 0, 0); ;
        xoy.transform.localPosition = new Vector3(0, 0, -0.01f);
        grid.transform.localPosition = new Vector3(0, 0, 0);

    }
    public void InitDrawGrid()
    {
        Created_XOY_Line();
        CreateGridList();
        SetColorWhite_Grid();
        SetDraw_Grid();
    }
    public void RefreshGraph()
    {
        InitDrawGrid();
        CreatedSplineCurrent();
    }
}
