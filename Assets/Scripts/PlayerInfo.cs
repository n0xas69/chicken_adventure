using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int life = 3;
    int coin = 0;
    public Image[] hearts;
    public Text coinText;
    public checkpoint check;
    public GameObject player;


    public void SetHealth(int val)
    {
        life += val;
        if (life > 3)
            life = 3;

        if (life <= 0)
        {
            life = 0;
            check.Respawn();

        }
       

        SetHealthBar();
    }

    public void GetCoin()
    {
        coin++;
        coinText.text = coin.ToString();
    }

    public void SetHealthBar()
    {
        foreach(Image img in hearts)
        {
            img.enabled = false;
        }

        for (int i=0; i < life; i++)
        {
            hearts[i].enabled = true;
        }
    }
}
