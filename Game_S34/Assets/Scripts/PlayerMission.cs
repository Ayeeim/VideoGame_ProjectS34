using UnityEngine;
using UnityEngine.SceneManagement;

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

        if(currentChaos > 100)
        {
            SceneManager.LoadScene("losing_screen");

        }
    }
}
