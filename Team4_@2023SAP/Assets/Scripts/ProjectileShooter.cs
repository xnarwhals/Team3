using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    Vector2 reticlePos;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.SendReticlePos>(ReceiveReticlePos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            EvtSystem.EventDispatcher.Raise(new GameEvents.ShootProjectile());
            reticlePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //temp

            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile p = projectilePrefab.GetComponent<Projectile>();
            p.direction = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
    }

    public void ReceiveReticlePos(GameEvents.SendReticlePos evt)
    {
        reticlePos = evt.reticlePos;
    }
}
