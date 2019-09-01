using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainManager : MonoBehaviour
{

    [HideInInspector]
    public States.StateManager stateManager = new States.StateManager();
    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartGame();
        //InitializeFirebaseAndStart();
    }

    // Update is called once per frame
    void Update()
    {
        stateManager.Update();
    }
    void FixedUpdate()
    {
        stateManager.FixedUpdate();
    }
    // void InitializeFirebaseAndStart()
    // {
    //     Firebase.DependencyStatus dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
    //
    //     if (dependencyStatus != Firebase.DependencyStatus.Available)
    //     {
    //         Firebase.FirebaseApp.FixDependenciesAsync().ContinueWith(task =>
    //         {
    //             dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
    //             if (dependencyStatus == Firebase.DependencyStatus.Available)
    //             {
    //                 StartGame();
    //             }
    //             else
    //             {
    //                 Debug.LogError(
    //                     "Could not resolve all Firebase dependencies: " + dependencyStatus);
    //                 Application.Quit();
    //             }
    //         });
    //     }
    //     else
    //     {
    //         StartGame();
    //     }
    // }
    void StartGame()
    {

        CommonData.prefabs = FindObjectOfType<PrefabList>();
        CommonData.canvasHolder = GameObject.Find("CanvasHolder");
        CommonData.drawGraph = FindObjectOfType<DrawGraph>();
        CommonData.mainManager = this;
        CommonData.stateManager = stateManager;
        //Firebase.AppOptions ops = new Firebase.AppOptions();
        //CommonDataJT.app = Firebase.FirebaseApp.Create(ops);
        //CommonDataJT.app.SetEditorDatabaseUrl(StringConstantsJT.LinkFirebaseDB);

        //  Screen.orientation = ScreenOrientation.Landscape;





        //stateManager.PushState(new States.Startup());
        //stateManager.PushState(new States.StartupJT());
    }
}
