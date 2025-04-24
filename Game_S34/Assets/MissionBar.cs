using UnityEngine;
using UnityEngine.UI;

public class MissionBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMinMission(int chaos)
    {
        slider.value = chaos;
        slider.minValue = chaos;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMission(int chaos)
    {
        slider.value = chaos;

        fill.color= gradient.Evaluate(slider.normalizedValue);
    }
}
