using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void mainMenu() {
        SceneManager.LoadScene(0);
    }
    public void game() {
        SceneManager.LoadScene(1);
    }
}
