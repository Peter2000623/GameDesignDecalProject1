using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The next component housing the current high score")]
    private Text m_Highscore;
    #endregion

    #region Variables
    private string m_DefaultHighScoreText;
    #endregion

    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_DefaultHighScoreText = m_Highscore.text;
    }

    private void Start()
    {
        UpdateHighScore();
    }
    #endregion

    #region Play Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("Arena");
    }
    #endregion

    #region General Apllication Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region High Score Methods
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_Highscore.text = m_DefaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_Highscore.text = m_DefaultHighScoreText.Replace("%S", "0");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighScore();
    }
    #endregion
}
