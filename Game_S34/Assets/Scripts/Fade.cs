using UnityEngine;

public class testScript : MonoBehaviour
{
    public DaySystem daySystem;

    public void FadeIn()
    {
        daySystem.DayEnd();
    }

    public void FadeOut()
    {
        //Not needed for now
    }
}
