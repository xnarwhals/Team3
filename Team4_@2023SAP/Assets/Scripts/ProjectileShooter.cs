using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float fireRate = 0.2f;

    Vector3 reticlePos;

    float firetimer;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.SendReticlePos>(ReceiveReticlePos);

        firetimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        firetimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(1))
        {
            if (firetimer >= fireRate)
            {
                firetimer = 0.0f;

                EvtSystem.EventDispatcher.Raise(new GameEvents.ShootProjectile());

                GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Projectile p = obj.GetComponent<Projectile>();
                p.direction = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            }
        }
    }

    public void ReceiveReticlePos(GameEvents.SendReticlePos evt)
    {
        reticlePos = evt.reticlePos;
    }
}
