using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level
{
    Intro,
    // TODO add levels here and below
}

public class Scenemanager : MonoBehaviour
{
    public Level previous, next;

    public string GetLevel(Level lvl)
    {
        switch (lvl)
        {
            case Level.Intro: return "Scenes/Intro";
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
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
        //TODO Franz
    }
    
    public void switchSceneToLevel(Level level)   //do level -1
    {
        StartCoroutine(switchSceneToLevelAsync(level));
    }
    IEnumerator switchSceneToLevelAsync(Level level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(GetLevel(level));
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
        //TODO Franz
    }
}
