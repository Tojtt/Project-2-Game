using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance = null;

    #region Unity_functions

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this.gameObject);        
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene_transitions

    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("You Win");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}

