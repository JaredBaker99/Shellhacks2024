using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
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
            SceneManager.LoadSceneAsync(3);
        }
    }
}
