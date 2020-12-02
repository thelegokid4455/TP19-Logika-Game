using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartGameSceneController : MonoBehaviour
{
    public Text gameText;
    public float gameTimer;
    public GameObject checkpointContainer;
    private int curCP;
    public int maxCP;

    private float bestTime = 99999;
    private bool finishedLap;

    // Start is called before the first frame update
    void Start()
    {
        foreach(CheckpointController cp in checkpointContainer.GetComponentsInChildren<CheckpointController>())
        {
            cp.onHitByPlayer = (int checkpointId) => OnReachCheckpoint(checkpointId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        gameText.text = "Time: " + Mathf.Floor(gameTimer);

        if (finishedLap)
        {
            gameText.text += "\nBest Time: " + Mathf.Floor(bestTime);
        }
    }

    void OnReachCheckpoint(int checkpointId)
    {
        Debug.Log(checkpointId);
        if(checkpointId == curCP +1)
        {
            curCP += 1;
        }
        if(checkpointId == 0 && curCP == maxCP)
        {
            Debug.Log("Lap Finished");
            curCP = 0;
            finishedLap = true;
            if(gameTimer < bestTime)
            {
                bestTime = gameTimer;
            }
            gameTimer = 0;
        }
    }
}
