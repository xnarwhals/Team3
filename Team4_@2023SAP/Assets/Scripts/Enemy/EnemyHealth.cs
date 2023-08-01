using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float defaultHealth = 3.0f;

    [HideInInspector]
    public float currentHealth;

    public int score = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = defaultHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0.0f)
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.EnemyDie() { enemy = gameObject });
            EvtSystem.EventDispatcher.Raise(new GameEvents.UpdateScore() { score = score });

            GetComponent<DroneMovement>().Die(); //temp
        }
    }
}
