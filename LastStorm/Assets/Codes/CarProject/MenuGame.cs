using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField]
    private Animator[] menus;

    [SerializeField]
    private Animator animTransition;

    [SerializeField]
    private Animator animPause;

    [SerializeField]
    private EventSystem evSystem;

    [SerializeField]
    private GameObject resumeButton;

    [SerializeField]
    private ScoreDistance scoreDist;

    [SerializeField]
    private SoundPlayer closeSound, openSound;

    private bool _onPause = false;
    // Start is called before the first frame update
    void Awake()
    {
        animPause.gameObject.SetActive(false);
        animTransition.gameObject.SetActive(true);
    }

    private void Start()
    {
        openSound.StartSounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpace()
    {
        if (!_onPause)
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        foreach(Animator g in menus)
        {
            g.SetTrigger("start");
        }
    }

    public void LaunchTransition()
    {
        animTransition.SetTrigger("close");
    }

    private void PauseGame()
    {
        evSystem.SetSelectedGameObject(resumeButton);
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = .01f;
        animPause.gameObject.SetActive(true);
        animPause.SetBool("pause", true);
        _onPause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
        animPause.SetBool("pause", false);
        _onPause = false;
    }

    public void restartGame()
    {
        if(scoreDist.ActualScore() > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreDist.ActualScore());
        }
        animTransition.SetTrigger("close");
        closeSound.StartSounds();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
