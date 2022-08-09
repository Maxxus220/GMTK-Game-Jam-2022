using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Try_Again : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
