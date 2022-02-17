using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    #region Initialization
    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Replay Button Methods
    public void Replay() {
        SceneManager.LoadScene("Main Scene");
    }
    #endregion

    #region General Application Button Methods
    public void Quit() {
        Application.Quit();
    }
    #endregion
}