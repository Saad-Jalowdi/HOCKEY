using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    public void Retry()
    {
        SceneManager.LoadScene("LVL");
    }
}
