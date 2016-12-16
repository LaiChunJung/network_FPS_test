﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Health : NetworkBehaviour {
    
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void TakeDamage(int amount)
    {
        if (!isServer) { return;}
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        
    }


    private void OnChangeHealth(int currentHealth)
    {
        float healthScale = maxHealth / currentHealth;
        healthBar.sizeDelta = new Vector2(healthScale, healthBar.sizeDelta.y);
    }
}
