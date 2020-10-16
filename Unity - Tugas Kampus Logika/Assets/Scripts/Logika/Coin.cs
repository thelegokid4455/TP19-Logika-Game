using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public AudioClip playAudio;
    public GameObject Player;
    public GameObject coinEffect;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerController>().coins += 1;
            Instantiate(coinEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            //GetComponent<AudioSource>().PlayOneShot(playAudio);
        }
    }
}
