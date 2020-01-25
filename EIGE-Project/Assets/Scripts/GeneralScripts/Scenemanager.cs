using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Level
{
    Intro,
    Level_1,
    DashLevel,
    DoubleJumpLevel,
    ShowCase,
    MainMenu,
    Level1DoubleJump,
    // TODO add levels here and below
}

public class Scenemanager : MonoBehaviour
{
    public Level previous, next;
    public GameObject loadingScreen;
    public Slider slider;
    public void Update()
    {
        loadingScreen.SetActive(false);
    }
    public string GetLevel(Level lvl)
    {
        switch (lvl)
        {
            case Level.Level1DoubleJump: return "Scenes/Level1DoubleJump";
            case Level.Intro: return "Scenes/Intro";
            case Level.DashLevel: return "Scenes/DashLevel";
            case Level.DoubleJumpLevel: return "Scenes/DoubleJumpLevel";
            case Level.ShowCase: return "Scenes/ShowCase";
            case Level.MainMenu: return "Scenes/MainMenu";
            // TODO add levels here and above
            default: throw new Exception("Couldn't resolve level!");

        }
    }
    
    public Scene returnCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }
    public void switchSceneMainMenu()
    {
        SceneManager.LoadScene(0);  //loads MainMenu
    }
    public void switchSceneToLevel(int level)   //do level -1
    {
        StartCoroutine(switchSceneToLevelAsync(level));
    }
    IEnumerator switchSceneToLevelAsync(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 9f);
            slider.value = progress;
            yield return null;
        }

    }
    public void switchSceneToLevel(Level level)   //do level -1
    {
        StartCoroutine(switchSceneToLevelAsync(level));
    }
    IEnumerator switchSceneToLevelAsync(Level level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GetLevel(level));
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 9f);
            slider.value = progress;
            yield return null;
        }
    }
    public void quitGame()
    {
        //Application.Quit();
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
