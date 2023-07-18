using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float defaultHealth = 3.0f;

    [DoNotSerialize]
    public float currentHealth;

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
            Destroy(gameObject);//temp maybe
        }
    }
}
