using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyHit>(SpawnParticles);
    }

    // Update is called once per frame
    void SpawnParticles(GameEvents.EnemyHit evt)
    {
        GameObject obj = Instantiate(particlePrefab, evt.enemy.transform);
        obj.GetComponent<ParticleSystem>().startColor = ProjectileShooter.Instance.color;
    }
}
