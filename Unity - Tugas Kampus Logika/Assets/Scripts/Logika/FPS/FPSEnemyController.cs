using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSEnemyController : MonoBehaviour
{
    public Vector3 chaseDirection;
    public float speed = 0.2f;

    public Action onDestroyed;
    public Action onHitPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            this.transform.position.x + chaseDirection.x * speed,
            this.transform.position.y,
            this.transform.position.z + chaseDirection.z * speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<BulletController>() != null)
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(other.gameObject);
            onDestroyed();
        }
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(other.gameObject);
            onHitPlayer();
        }
    }
}
