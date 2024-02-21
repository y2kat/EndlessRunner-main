using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CoinsManager coinsManager; 
    public int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log(coinCount);
            coinsManager.DespawnObject(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("DeadScene");
        }
    }
}
