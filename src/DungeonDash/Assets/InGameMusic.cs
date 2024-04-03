using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMusic : MonoBehaviour
{
    public AudioClip bossMusic;

    private AudioSource audioSource;
    private string sceneName;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;
        PlayMusic();
    }

    void PlayMusic()
    {
        if (sceneName.Contains("Boss"))
        {
            audioSource.clip = bossMusic;
            audioSource.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}