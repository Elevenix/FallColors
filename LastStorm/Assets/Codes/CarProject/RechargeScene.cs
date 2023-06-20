using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RechargeScene : MonoBehaviour
{
    public void RestartScene()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
        SceneManager.LoadScene(0);
    }
}
