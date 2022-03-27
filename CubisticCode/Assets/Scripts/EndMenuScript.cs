using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuScript : MonoBehaviour
{
    public Text DeathCount;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

       if (PlayerPrefs.GetInt("DeathScore", -1) == -1 || PlayerPrefs.GetInt("DeathScore", -1) > PlayerPrefs.GetInt("Deaths", -1))
              PlayerPrefs.SetInt("DeathScore", PlayerPrefs.GetInt("Deaths", -1));

        DeathCount.text = "Deaths: " + PlayerPrefs.GetInt("Deaths", 0).ToString();
        PlayerPrefs.SetInt("Completed", 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
