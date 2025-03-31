using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void GoScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);

    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
