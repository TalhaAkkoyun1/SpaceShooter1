using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBycontact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameCont gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameCont>();
        }
        if (gameController == null)
        {
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (gameObject.CompareTag("Enemy"))
        {
            

        }
        if (other.CompareTag("boundary") || other.CompareTag("Enemy"))
        {

            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
