using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBycontact : MonoBehaviour
{
    public GameObject explotionEffect, playerExplosionEffect;
    public int scoreValue;
    public GameCont GameCont;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameCont = gameControllerObject.GetComponent<GameCont>();
    }

    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("boundry"))
        {
            return;
        }

        Instantiate(explotionEffect, transform.position, Quaternion.identity);
        GameCont.AddScore(scoreValue);

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosionEffect, transform.position, Quaternion.identity);
            GameCont.GameOver();
            Debug.Log("öldün");
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
