using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu2 : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(WaitBeforePlay());
    }
    public void QuitGame()
    {
        StartCoroutine(WaitBeforeQuit());
    }
    IEnumerator WaitBeforePlay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(1);
    }
    IEnumerator WaitBeforeQuit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}