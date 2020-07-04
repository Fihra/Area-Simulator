using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsPage;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    void Update()
    {
        //Debug.Log(instructionsPage.activeInHierarchy == true);
        if (instructionsPage.activeInHierarchy == true && Input.GetKeyDown("space"))
        {
            PlayGame();
        }
    }
}
