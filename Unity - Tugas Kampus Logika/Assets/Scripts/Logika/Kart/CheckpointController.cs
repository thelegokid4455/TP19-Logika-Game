using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointController : MonoBehaviour
{
    public int checkpointId;
    public Action<int> onHitByPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            onHitByPlayer(checkpointId);
        }
    }
}
