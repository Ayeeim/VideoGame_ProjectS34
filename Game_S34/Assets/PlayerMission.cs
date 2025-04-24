using UnityEngine;

public class PlayerMission : MonoBehaviour
{
    public int minChaos;
    public int currentChaos;

    public MissionBar missionBar;

    void Start()
    {
        currentChaos = minChaos;
        missionBar.SetMinMission(minChaos);
    }

    public void TakeChaos(int chaos)
    {
        currentChaos += chaos;
        missionBar.SetMission(currentChaos);
    }
}
