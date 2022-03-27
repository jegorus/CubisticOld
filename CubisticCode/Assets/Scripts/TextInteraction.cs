using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextInteraction : MonoBehaviour
{
    public GameObject RestartText;
    public GameObject AirJumpText;
    public GameObject MenuText;

    void Start()
    {
        int Count = PlayerPrefs.GetInt("Level1", 1);
        if (Count == 1)
            StartCoroutine("Destroying");
    }

    IEnumerator Destroying()
    {
        PlayerPrefs.SetInt("Level1", 2);
        RestartText.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(RestartText);

        yield return new WaitForSeconds(1);

        AirJumpText.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(AirJumpText);

        yield return new WaitForSeconds(1);

        MenuText.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(MenuText);
    }

}
