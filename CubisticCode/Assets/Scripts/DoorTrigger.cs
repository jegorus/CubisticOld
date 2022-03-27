using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameManagerScript levelManager;

    private void OnTriggerEnter2D()
    {
       levelManager.LoadNextLevel();
    }
}
