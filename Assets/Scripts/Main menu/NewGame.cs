using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void StartTime()
    {
        Time.timeScale = 1f;

    }

    public string newGameLevel;
    public void NewGameDialogYes()
    {

        SceneManager.LoadScene("Jueguito");


    }
    public void Quit()
    {
        Application.Quit();
    }


}
