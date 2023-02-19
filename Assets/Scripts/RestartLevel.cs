using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private Scene currentScene;

    public static void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
