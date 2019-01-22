using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour {

    public enum Score
    {
        AiScore, PlayerScore
    }
    public GameObject Pannel, pausePannel;

    public Text AiScoreTxt, PlayerScoreTxt, StatusText;
    private int aiScore, playerScore;
    private void Update()
    {
        if (playerScore == 7 || aiScore == 7)
        {
            Pannel.SetActive(true);
            if (playerScore == 7)
                StatusText.text = "you win !";
            else if (aiScore == 7)
                StatusText.text = "you lost !";
        }
    }
    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
            AiScoreTxt.text = (++aiScore).ToString();
        else
            PlayerScoreTxt.text = (++playerScore).ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        Pannel.SetActive(false);
        SceneManager.LoadScene("LVL");
    }
    public void mainMenu()
    {
        Pannel.SetActive(false);
        SceneManager.LoadScene("Main Menu");
    }
    public void pause()
    {
        Time.timeScale = 0.0f;
        pausePannel.SetActive(true);
    }
    public void resume(){
        pausePannel.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
