using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameController gameController;

    private void Start()
    {
        // Get access to GameController script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
        void OnTriggerEnter(Collider other)
        {
        // Don't destroy inside boundary
            if (other.tag == "Boundary")
            {
                return;
            }
        
            //only gameOver if obstacle hits the player not another item
            if (!other.CompareTag("SpeedBoost"))
            {
                // Add explosion particle upon death, stop game, destroy obstacle and player, access GameOver-function
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Time.timeScale = 0;
                Destroy(other.gameObject);
                Destroy(gameObject);
                gameController.GameOver();
            }
        }
}