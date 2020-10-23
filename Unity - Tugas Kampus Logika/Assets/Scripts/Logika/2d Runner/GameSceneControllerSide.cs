using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneControllerSide : MonoBehaviour
{
    public PlayerControllerSide player;
    public Camera gameCamera;

    public GameObject[] blockPrefab;
    private int curPlat;

    private float blockPointer = -10f;
    private float safeMargin = 20f;

    public Text gameText;

    // Start is called before the first frame update
    void Start()
    {
        //curPlat = 1;
        
        //newBlock();
        
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
        //newBlock();
        if (player != null)
        {
            gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
            gameText.text = "Score: " + Mathf.Floor(player.transform.position.x);
        }

        

        while (player != null && blockPointer < player.transform.position.x + safeMargin)
        {
            int blockIndex = Random.Range(0, blockPrefab.Length);
            if (blockPointer <= 20)
                blockIndex = 0;
            GameObject blockObj = GameObject.Instantiate<GameObject>(blockPrefab[blockIndex]);
            blockObj.transform.SetParent(this.transform);
            BlockController block = blockObj.GetComponent<BlockController>();
            blockObj.transform.position = new Vector3(blockPointer + block.sizeX / 2, 0, 0);
            blockPointer += block.sizeX;
            
        }

        if(player == null)
        {
            gameText.text += "\nPress R to Restart";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
