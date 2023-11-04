using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : SingletonLite<ProjectileShooter>
{
    public GameObject projectilePrefab;

    public float fireRate = 0.2f;

    public bool holdToFire = true;

    public float PaintCost = 5.0f;

    float firetimer;

    PaintExample paintExample;

    public Color color = Color.white;

    public List<Color> colors = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        firetimer = fireRate;

        paintExample = FindAnyObjectByType<PaintExample>(); //this is bad

        EvtSystem.EventDispatcher.AddListener<GameEvents.ColorWheelChange>(ColorChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.0f)
            return;

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

                paintExample.currentRegenSpeed = paintExample.paintRegenSpeed;
                paintExample.PlayerUsePaint(PaintCost);

                GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                Projectile p = obj.GetComponent<Projectile>();
                p.direction = (Vector2)(Reticle.Instance.transform.position - transform.position);

                obj.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    void ColorChange(GameEvents.ColorWheelChange evt)
    {
        color = colors[evt.ChangedColor];
    }
}
