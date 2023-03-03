using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private bool paused;
    public GameObject menuUI;

    public void Resume()
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        paused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        paused = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        // Add commands to zero-out any scores or other stats before restarting
        SceneManager.LoadScene("MainMenu");
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        volumeLevel = sliderValue;
    }

    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;

    void Awake()
    {
        SetLevel(volumeLevel);
    }

    public void QuitGame(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif

}
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
 

}
}
