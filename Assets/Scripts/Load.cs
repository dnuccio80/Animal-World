using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load 
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene,
    }

    private static Scene targetScene;

    public static void LoadCallbackScene(Scene scene) 
    {
        targetScene = scene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }

    public static void LoadScene()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

}

