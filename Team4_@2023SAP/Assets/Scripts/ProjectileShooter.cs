using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : Singleton<ProjectileShooter>
{
    public GameObject projectilePrefab;

    public float fireRate = 0.2f;

    public bool holdToFire = true;

    float firetimer;

    // Start is called before the first frame update
    void Start()
    {
        firetimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (firetimer < fireRate)
        {
            firetimer += Time.deltaTime;
        }

        bool canfire = holdToFire ?
            Input.GetMouseButton(1) || Input.GetKey(KeyCode.JoystickButton1) :
            Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.JoystickButton1);

        if (canfire)
        {
            if (firetimer >= fireRate)
            {
                firetimer = 0.0f;

                EvtSystem.EventDispatcher.Raise(new GameEvents.ShootProjectile());

                GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Projectile p = obj.GetComponent<Projectile>();
                p.direction = (Vector2)(Reticle.Instance.transform.position - transform.position);
            }
        }
    }
}
