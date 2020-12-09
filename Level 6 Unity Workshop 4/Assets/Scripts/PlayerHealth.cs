﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    ActivateRagdoll activateRagdoll;
    public bool ragdollActivated;
    enemyController enemyController;
    CanvasGroup damageOverlay;
    bool PlayerCanDie;
       
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        activateRagdoll = GetComponent<ActivateRagdoll>();
        enemyController = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyController>();       
        damageOverlay = GameObject.Find("DamageOverlay").GetComponent<CanvasGroup>();        
        PlayerCanDie = true;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);    
    }
   
    void Update()
    {
        //if (Input.GetButtonDown("HealthTest"))
        //{
        //    TakeDamage(20);
        //}
        if (currentHealth <= 0 && PlayerCanDie)
        {
            playerDies();
            PlayerCanDie = false;
        }
    }
    public void playerDies()
    {
        activateRagdoll.ragdoolEnabled(true);
        enemyController.ragdollActivated();
        StartCoroutine(damageFade());
    }
    IEnumerator damageFade()
    {
       
            damageOverlay.alpha = 1f;
            yield return new WaitForSeconds(0.3f);
            damageOverlay.alpha = 0f;        
    }
    

    
}
