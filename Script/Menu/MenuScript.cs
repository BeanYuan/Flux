using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayScene() {
        SceneManager.LoadScene("Scene1");
    }

    public void Credit() {
        SceneManager.LoadScene("Credit");
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
