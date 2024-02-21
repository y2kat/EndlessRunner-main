using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player; 
    public TMP_Text coinText;
    public TMP_Text distanceText;
    public PlayerController playerController;

    void Update()
    {
        coinText.text = "Coins: " + player.coinCount;
        distanceText.text = "Distance: " + playerController.distanceTravelled.ToString("0.00");
    }
}
