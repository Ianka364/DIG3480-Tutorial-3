using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject!=null)
        {
            gameController = gameController.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
