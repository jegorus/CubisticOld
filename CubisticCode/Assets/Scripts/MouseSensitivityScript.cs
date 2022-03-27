using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityScript : MonoBehaviour
{
    public Slider MouseSensSlider;

    private void Start()
    {
        MouseSensSlider.normalizedValue = PlayerPrefs.GetFloat("MouseSensitivity", 0.4f);
    }

    public void MousSensChange(float newSens)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", newSens);
    }
}
