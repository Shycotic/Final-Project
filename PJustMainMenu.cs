using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
       
        SceneManager.LoadScene("GameManagerHolder");

        int index = Random.Range(1, 3);
        SceneManager.LoadScene(index);
        Debug.Log("Scene " + index + " Loaded!");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
