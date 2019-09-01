using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Menus
{
    public class X__2_GUI : BaseMenu
    {

        public GUIButton Exit_Setting;
        public GUIButton Setting;
        public GameObject Menu;
        public GameObject Editor;
        public GameObject Desk;
        public Slider Slider_Scale;
        public Slider Slider_NumberLine;
        public Slider Slider_Y_Rotate;
        public Slider Slider_X_Position;
        public Slider Slider_Z_Position;
        public Slider Slider_A;
        public Slider Slider_B;
        public Slider Slider_C;

        float A;
        float B;
        float C;
        List<Vector3> spline_Current_Points;
        private void Start()
        {
            spline_Current_Points = new List<Vector3>();
            A = Slider_A.value;
            B = Slider_B.value;
            C = Slider_C.value;
            Desk = CommonData.prefabs.assetLookup[StringConstants.AssetDesk];
            if (CommonData.color_State == 0)
            {
                CommonData.drawGraph.SetColorWhite_Grid();
            }
            else
            {
                CommonData.drawGraph.SetColorGreen_Grid();
            }
            CreatArrayCurrentSpline();
            Debug.Log("number=" + spline_Current_Points.Count);
            CommonData.drawGraph.CreatedSplineCurrent();
        }
        public void CreatArrayCurrentSpline()
        {
            CommonData.drawGraph.spline_Current_Points.Clear();
            for (float i = -CommonData.numberOfLines; i <= CommonData.numberOfLines; i += CommonData.numberOfLines / 200f)
            {
                //Debug.Log(index);
                // spline.points3[index] = new Vector3(i, i * i, 0);
                //index++;
                if (A * Mathf.Pow((i + B), 2) + C <= CommonData.numberOfLines && A * Mathf.Pow((i + B), 2) + C >= -CommonData.numberOfLines)
                {
                    CommonData.drawGraph.spline_Current_Points.Add(new Vector3(i * CommonData.distanceBetweenLines, (A * Mathf.Pow((i + B), 2) + C) * CommonData.distanceBetweenLines, 0));
                }
            }
        }
        public void SetEditor()
        {
            Menu.SetActive(false);
            Editor.SetActive(true);
            Slider_Scale.value = Desk.transform.localScale.x;
            Slider_Y_Rotate.value = CommonData.Slider_Y_Rotate;
            Slider_NumberLine.value = CommonData.numberOfLines;
            Slider_X_Position.value = CommonData.Slider_X_position;
            Slider_Z_Position.value = CommonData.Slider_Z_position;
        }
        public void SetMenu()
        {
            Menu.SetActive(true);
            Editor.SetActive(false);
        }
        public void SetRotate(float value_sl)
        {
            CommonData.Slider_Y_Rotate = value_sl;
            Desk.transform.eulerAngles = new Vector3(Desk.transform.eulerAngles.x, CommonData.Y_Rotate + value_sl, Desk.transform.eulerAngles.z);
        }
        public void Set_X_Position(float value_sl)
        {
            CommonData.Slider_X_position = value_sl;
            Desk.transform.localPosition = new Vector3(CommonData.X_position + value_sl, Desk.transform.localPosition.y, Desk.transform.localPosition.z);
        }
        public void Set_Z_Position(float value_sl)
        {
            CommonData.Slider_Z_position = value_sl;
            Desk.transform.localPosition = new Vector3(Desk.transform.localPosition.x, Desk.transform.localPosition.y, CommonData.Z_position + value_sl);
        }
        public void Set_NumberLines(float value_sl)
        {
            CommonData.numberOfLines = (int)value_sl;
            CommonData.distanceBetweenLines = CommonData.Lenght / (2 * CommonData.numberOfLines);
            CreatArrayCurrentSpline();
            CommonData.drawGraph.RefreshGraph();

        }
        public void Set_Scale(float value_sl)
        {


            Desk.transform.localScale = new Vector3(value_sl, value_sl, value_sl);
            CreatArrayCurrentSpline();
            CommonData.drawGraph.RefreshGraph();

        }
        public void SetGreen()
        {
            CommonData.color_State = 1;
            CommonData.drawGraph.SetColorGreen_Grid();
        }
        public void SetWhite()
        {
            CommonData.color_State = 0;
            CommonData.drawGraph.SetColorWhite_Grid();
        }
        public void Set_A(float value_sl)
        {
            A = value_sl;
            CreatArrayCurrentSpline();
            CommonData.drawGraph.CreatedSplineCurrent();
        }
        public void Set_B(float value_sl)
        {
            B = value_sl;
            CreatArrayCurrentSpline();
            CommonData.drawGraph.CreatedSplineCurrent();
        }
        public void Set_C(float value_sl)
        {
            C = value_sl;
            CreatArrayCurrentSpline();
            CommonData.drawGraph.CreatedSplineCurrent();
        }
        public void OnAnimaK()
        {
            //StartCoroutine(Anim());
            for (int i = 0; i < CommonData.drawGraph.spline_Current_Points.Count; i++)
            {
                if (CommonData.drawGraph.spline_Current_Points[i].y < 0)
                {
                    CommonData.drawGraph.spline_Current_Points[i] = new Vector3(CommonData.drawGraph.spline_Current_Points[i].x, -CommonData.drawGraph.spline_Current_Points[i].y, CommonData.drawGraph.spline_Current_Points[i].z);
                    
                   
                }
            }
            CommonData.drawGraph.RefreshGraph();
        }
        IEnumerator Anim()
        {
            for (int i = 0; i < CommonData.drawGraph.spline_Current_Points.Count; i++)
            {
                if (CommonData.drawGraph.spline_Current_Points[i].y < 0)
                {
                    CommonData.drawGraph.spline_Current_Points[i] = new Vector3(CommonData.drawGraph.spline_Current_Points[i].x, -CommonData.drawGraph.spline_Current_Points[i].y, CommonData.drawGraph.spline_Current_Points[i].z);
                    CommonData.drawGraph.RefreshGraph();
                    yield return new WaitForSeconds(.00001f);
                }
            }
           

        }
    }
}
