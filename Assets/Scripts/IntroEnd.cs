using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroEnd : MonoBehaviour
{
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scne with the Singel mode
        SceneManager.LoadScene("GameLevel", LoadSceneMode.Single);
    }
}
