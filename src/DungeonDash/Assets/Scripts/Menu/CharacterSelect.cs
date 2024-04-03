using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void Archer()
    {
        SceneManager.LoadScene(2);
    }

    public void Mage()
    {
        SceneManager.LoadScene(19);
    }
}
