using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class X__2 : BaseState
    {

        
        Menus.X__2_GUI X__2_GUI_Component;

        public X__2()
        {
            
        }

        public override void Initialize()
        {
            Debug.Log("Init X__2");
            X__2_GUI_Component = SpawnUI<Menus.X__2_GUI>(StringConstants.Prefab_X__2_Menu);
            X__2_GUI_Component.SetMenu();
        }

        public override void Resume(StateExitValue results)
        {
            ShowUI();
        }

        public override void Suspend()
        {
            HideUI();
        }

        public override StateExitValue Cleanup()
        {
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {
            if (source == X__2_GUI_Component.Exit_Setting.gameObject)
            {
                X__2_GUI_Component.SetMenu();
            }
            if (source == X__2_GUI_Component.Setting.gameObject)
            {
                X__2_GUI_Component.SetEditor();
            }
        }
    }
}
