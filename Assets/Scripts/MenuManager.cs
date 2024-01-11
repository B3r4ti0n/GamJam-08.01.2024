using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        //Quit app
        // Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);

    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene 1", LoadSceneMode.Single);

    }
}
