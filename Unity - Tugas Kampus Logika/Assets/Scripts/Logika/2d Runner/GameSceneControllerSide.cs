using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneControllerSide : MonoBehaviour
{
    public PlayerControllerSide player;
    public Camera gameCamera;

    public GameObject[] blockPrefab;
    private int curPlat;

    // Start is called before the first frame update
    void Start()
    {
        curPlat = 1;
        GameObject block = GameObject.Instantiate<GameObject>(blockPrefab[0]);
        block.transform.SetParent(this.transform);
        block.transform.position = new Vector3(0, 0, 0);
        newBlock();
        
    }

    void newBlock()
    {
        GameObject blockNew = GameObject.Instantiate<GameObject>(blockPrefab[0]);
        blockNew.transform.SetParent(this.transform);
        blockNew.transform.position = new Vector3(blockNew.GetComponent<BlockController>().sizeX * curPlat, 0, 0);
        if (curPlat <= 3)
            curPlat += 1;
    }

    // Update is called once per frame
    void Update()
    {
        newBlock();
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
    }
}
