using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Menus
{
    public class MainMenuGUI : BaseMenu
    {

        public GUIButton Exit;
        public GUIButton Setting;
        public GUIButton X__2;
        public GameObject Menu;
        public GameObject Editor;
        public GameObject Desk;
        public Slider Slider_Scale;
        public Slider Slider_Y_Rotate;
        public Slider Slider_X_Position;
        public Slider Slider_Z_Position;
        private void Start()
        {
            Desk = CommonData.prefabs.assetLookup[StringConstants.AssetDesk];
            if(CommonData.color_State==0)
            {
                CommonData.drawGraph.SetColorWhite_Grid();
            }
            else
            {
                CommonData.drawGraph.SetColorGreen_Grid();
            }
        }
        public void SetEditor()
        {
            Menu.SetActive(false);
            Editor.SetActive(true);
            Slider_Y_Rotate.value = CommonData.Slider_Y_Rotate;
            Slider_Scale.value= CommonData.numberOfLines;
            Slider_X_Position.value=CommonData.Slider_X_position;
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
            Desk.transform.eulerAngles = new Vector3(Desk.transform.eulerAngles.x, CommonData.Y_Rotate+value_sl, Desk.transform.eulerAngles.z);
        }
        public void Set_X_Position(float value_sl)
        {
            Debug.Log("value_sl=" + value_sl);
            CommonData.Slider_X_position = value_sl;
            Debug.Log("pos=" + Desk.transform.localPosition);
            Debug.Log("forward=" + Desk.transform.forward);
            Vector3 destination = new Vector3(CommonData.X_position, Desk.transform.localPosition.y, CommonData.Z_position) + Desk.transform.forward * value_sl;
            Debug.Log("destination=" + destination);
            Desk.transform.localPosition = destination;
            // Desk.transform.localPosition = new Vector3(CommonData.X_position + value_sl, Desk.transform.localPosition.y,  Desk.transform.localPosition.z);
            //Desk.transform.localPosition = new Vector3(destination.x, Desk.transform.localPosition.y, destination.z);
        }
        public void Set_Z_Position(float value_sl)
        {
            CommonData.Slider_Z_position = value_sl;
            Desk.transform.localPosition = new Vector3(Desk.transform.localPosition.x,  Desk.transform.localPosition.y, CommonData.Z_position + value_sl);
        }
        public void Set_NumberLines(float value_sl)
        {
            CommonData.numberOfLines = (int)value_sl;
            CommonData.distanceBetweenLines = CommonData.Lenght / (2 * CommonData.numberOfLines);
            CommonData.drawGraph.RefreshGraph();
            
        }
        public void Set_Scale(float value_sl)
        {
           
            
            Desk.transform.localScale = new Vector3(value_sl, value_sl, value_sl);
            
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
    }
}
