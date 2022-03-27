using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public ParticleSystem DeathParticles;
    public GameObject player;
    public SpriteRenderer playerModel;
    public Movement moveScript;
    public Rigidbody2D rb;
    public Text DeathCount;

    bool shouldRestart = false;

   public void Die()
    {
        if (!shouldRestart)
        {
            FindObjectOfType<AudioManagerScript>().Play("PlayerDeath");
            shouldRestart = true;
            Instantiate(DeathParticles, player.transform);
            playerModel.enabled = false;
            moveScript.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        //    Destroy(player, 0.1f);
            Invoke("Restart", 0.5f);

            PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths", 0) + 1);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void LoadNextLevel()
    {
        if (!shouldRestart)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public bool ShouldRestart()
    {
        return shouldRestart;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }


    private void Awake()
    {
        if (PlayerPrefs.GetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 0) == 0)
            PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 1);
    }

    private void Update()
    {
        DeathCount.text = PlayerPrefs.GetInt("Deaths", 0).ToString();
    }
}
