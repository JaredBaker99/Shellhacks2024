using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PLayerHealth : MonoBehaviour
{
    private float health = 0f;

    [SerializeField] private float maxHealth = 100f;

    private void Start() {
        health = maxHealth;
    }

    public void UpdateHealth(float mod) 
    {
        health += mod;

        if (health > maxHealth) { // capping max health
            health = maxHealth;
        } else if (health <= 0) {
            health = 0f;
            Debug.Log("Player Respawn");
        }
    }
}
