using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class FPSGameSceneController : MonoBehaviour
{
    public GameObject hero;
    public GameObject enemyPrefab;

    private float enemySpawnDistance = 15;

    private float enemyTimer = 0;
    private float enemySpawnInterval = 3;

    public Text infoText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime * 1;
        GameObject enemyObject = enemyPrefab;

        if (enemyTimer <= 0 && hero!= null)
        {
            enemyTimer = enemySpawnInterval;
            Debug.Log("Spawn Enemy");

            float spawnAngle = Random.Range(0, 360);
           
            //enemyObject.transform.position = new Vector3(3, 1, 0);
            enemyObject.transform.position = new Vector3(
                hero.transform.position.x + Mathf.Cos(spawnAngle) * enemySpawnDistance,
                hero.transform.position.y,
                hero.transform.position.z + Mathf.Sin(spawnAngle)*enemySpawnDistance);
            enemyObject = Instantiate<GameObject>(enemyPrefab);

        }

        if(Input.GetKeyDown("r"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        FPSEnemyController enemy = enemyObject.transform.GetComponent<FPSEnemyController>();
        enemy.chaseDirection = (hero.transform.position - enemy.transform.position).normalized;
        enemy.onDestroyed = () =>
        {
            score += 100;
            infoText.text = "Score: " + score.ToString();
            Debug.Log("Enemy Destroyed");
        };
        enemy.onHitPlayer = () =>
        {
            Time.timeScale = 0;
            infoText.text = "\nGame Over! Press R to Restart";
            Debug.Log("Enemy Destroyed");
        };
    }
}
