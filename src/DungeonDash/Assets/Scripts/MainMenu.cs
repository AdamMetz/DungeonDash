using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //CharacterSelectionPage-replace with SceneNumber
    }

    // Update is called once per frame
    public void AboutPage()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
