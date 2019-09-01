using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class MainMenu : BaseState
    {

        
        Menus.MainMenuGUI MainMenuComponent;

        public MainMenu()
        {
            
        }

        public override void Initialize()
        {
            Debug.Log("Init MainMenu");
            MainMenuComponent = SpawnUI<Menus.MainMenuGUI>(StringConstants.PrefabMainMenu);
            MainMenuComponent.SetMenu();
            CommonData.drawGraph.InitDrawGrid();
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
            if (source == MainMenuComponent.Exit.gameObject)
            {
                MainMenuComponent.SetMenu();
            }
            if (source == MainMenuComponent.Setting.gameObject)
            {
                MainMenuComponent.SetEditor();
            }
            if (source == MainMenuComponent.X__2.gameObject)
            {
                manager.PushState(new X__2());
            }
        }
    }
}
