using UnityEngine;

public class EventManager : MonoBehaviour
{

    public bool isTag; //True pour event Tag activé
    public bool isFire; //True pour l'event incendie
    public bool isRadioactive; //True pour l'event radioactif
    public bool isTrap; // True pour l'event braconnage
    [SerializeField] PlayerMission playerMission;

    [SerializeField] private SpriteRenderer cabane;
    [SerializeField] private Sprite cabaneClean;
    [SerializeField] private Sprite cabaneTag;

    public void TagEvent()
    {
        Debug.Log("La cabane a été tagguée");
        cabane.sprite = cabaneTag;
        isTag = true;
    }

    private void Awake()
    {
        TagEvent();
    }

    public void TakeDamageEvent()
    {
        if(isTag) { playerMission.TakeChaos(25); }
        if (isFire) { playerMission.TakeChaos(20); }
        if (isRadioactive) { playerMission.TakeChaos(20);}
        if (isTrap) {  playerMission.TakeChaos(20); }
    }
}
