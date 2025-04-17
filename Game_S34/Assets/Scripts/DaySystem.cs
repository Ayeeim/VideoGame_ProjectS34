using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public int dayCount;

    // Timer qui s'ex�cute, d�s que le timer se fini un nouveau jour est lanc�
    // Le timer est r�gl� sur 3 min le jour s'effectue sur 12 heure fictive (un rythme de 15sec pour une heure -> 15*12=180)
    public float targetTime = 180.0f;
    public float actualTime = 0f;

    private void Update()
    {
        if (targetTime > actualTime)
        {
            actualTime += Time.deltaTime;
        }
    }
}
