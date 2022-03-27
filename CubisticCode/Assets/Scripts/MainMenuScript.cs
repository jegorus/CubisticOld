using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Text Level1Text;
    public Text Level2Text;
    public Text Level3Text;
    public Text Level4Text;
    public Text Level5Text;
    public Text Level6Text;
    public Text Level7Text;

    public GameObject DeathScoreObject;
    public Text DeathScore;


    private void Start()
    {
       Cursor.lockState = CursorLockMode.None;
       Cursor.visible = true;
       SetDeathScore();
       SetLevelColors();
    }

    void SetDeathScore()
    {
        if (PlayerPrefs.GetInt("Completed", 0) == 1)
        {
            DeathScoreObject.SetActive(true);
            DeathScore.text = "DeathScore: " + PlayerPrefs.GetInt("DeathScore", -1);
        }
        else DeathScoreObject.SetActive(false);
    }

    void SetLevelColors()
    {
        if (PlayerPrefs.GetInt("Level1", 0) == 0) Level1Text.color = Color.black;
        else Level1Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level2", 0) == 0) Level2Text.color = Color.black;
        else Level2Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level3", 0) == 0) Level3Text.color = Color.black;
        else Level3Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level4", 0) == 0) Level4Text.color = Color.black;
        else Level4Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level5", 0) == 0) Level5Text.color = Color.black;
        else Level5Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level6", 0) == 0) Level6Text.color = Color.black;
        else Level6Text.color = Color.white;
        if (PlayerPrefs.GetInt("Level7", 0) == 0) Level7Text.color = Color.black;
        else Level7Text.color = Color.white;
    }

    public void StartNewGame()
    {
        PlayerPrefs.SetInt("LevelsNumber", 7);
        PlayerPrefs.SetInt("Deaths", 0);
        for (int i = 1; i <= PlayerPrefs.GetInt("LevelsNumber", 0); ++i) {
          PlayerPrefs.SetInt("Level" + i.ToString(), 0);
        }
        SceneManager.LoadScene(1);
    }

    public void StartLevel(int i)
    {
        if (PlayerPrefs.GetInt("Level" + i.ToString(), 1) > 0 && i <= PlayerPrefs.GetInt("LevelsNumber", 0))
            SceneManager.LoadScene(i);
    }


    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
        SetDeathScore();
        SetLevelColors();
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
