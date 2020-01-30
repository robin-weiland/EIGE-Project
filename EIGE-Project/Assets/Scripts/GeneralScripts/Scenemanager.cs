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
    GravityLevel,
    // TODO add levels here and below
}

public class Scenemanager : MonoBehaviour
{
    public Level previous, next;
    
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
            case Level.GravityLevel: return "Scenes/GravityLevel";
            // TODO add levels here and above
            default: throw new Exception("Couldn't resolve level!");

        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        SceneManager.LoadScene(level);
    }

    public void switchSceneToLevel(Level level)   //do level -1
    {
        SceneManager.LoadScene(GetLevel(level));
    }

    public void quitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit(); //quits in builded version
    #endif
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            this.switchSceneToLevel(2);
        }
        if (Input.GetKeyDown("2"))
        {
            this.switchSceneToLevel(3);
        }
        if (Input.GetKeyDown("3"))
        {
            this.switchSceneToLevel(4);
        }
    }
    
}
