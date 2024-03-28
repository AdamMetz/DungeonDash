using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public int maxHealth = 3;
    RawImage[] hearts = new RawImage[3];
    private void Start()
    {
        hearts[0] = transform.Find("Hearts").Find("Heart1").GetComponent<RawImage>();
        hearts[1] = transform.Find("Hearts").Find("Heart2").GetComponent<RawImage>();
        hearts[2] = transform.Find("Hearts").Find("Heart3").GetComponent<RawImage>();
    }

    public void UpdateHealthBar(int currentHealth) 
    {
        for (int i = 1; i <= maxHealth; i++)
        {
            if (currentHealth >= i)
            {
                hearts[(i - 1)].enabled = true;
                continue;
            }
            hearts[(i - 1)].enabled = false;
        }
    }
}
