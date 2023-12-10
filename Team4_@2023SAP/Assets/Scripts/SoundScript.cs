using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static GameEvents;

public class SoundScript : MonoBehaviour
{
    public AudioClip DroneScan;
    public AudioClip DroneHit;
    public AudioClip DroneDeath;

    public AudioClip ShootPaint;
    public AudioClip ShootProjectile;
    public AudioClip PaintEmpty;
    public AudioClip colorWheel;

    public AudioClip DroneEnter;

    public AudioClip GameOverRiff;

    public AudioClip MarketTalking;
    private GameObject marketTalkingSource;

    public GameObject AudioSourcePrefab;

    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        EvtSystem.EventDispatcher.AddListener<GameEvents.ScanStart>(scan);
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyHit>(droneHit);
        EvtSystem.EventDispatcher.AddListener<GameEvents.EnemyDie>(droneDeath);

        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootPaint>(shootPaint);
        EvtSystem.EventDispatcher.AddListener<GameEvents.ShootProjectile>(shootProjectile);
        EvtSystem.EventDispatcher.AddListener<GameEvents.ColorWheelChange>(ColorWheel);
        EvtSystem.EventDispatcher.AddListener<GameEvents.PaintEmpty>(paintEmpty);

        EvtSystem.EventDispatcher.AddListener<GameEvents.StartDialogue>(StartDialogue);
        EvtSystem.EventDispatcher.AddListener<GameEvents.EndDialogue>(EndDialogue);

        EvtSystem.EventDispatcher.AddListener<GameEvents.DroneWaveEnter>(droneEnter);

        EvtSystem.EventDispatcher.AddListener<GameEvents.GameOver>(GameOver);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ScanStart>(scan);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.EnemyHit>(droneHit);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.EnemyDie>(droneDeath);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ShootPaint>(shootPaint);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ShootProjectile>(shootProjectile);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.ColorWheelChange>(ColorWheel);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.PaintEmpty>(paintEmpty);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.StartDialogue>(StartDialogue);
        EvtSystem.EventDispatcher.RemoveListener<GameEvents.EndDialogue>(EndDialogue);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.DroneWaveEnter>(droneEnter);

        EvtSystem.EventDispatcher.RemoveListener<GameEvents.GameOver>(GameOver);
    }

    void scan(GameEvents.ScanStart evt)
    {
        AudioSource.PlayClipAtPoint(DroneScan, evt.enemy.transform.position, volume * 1.5f);
    }

    void droneHit(GameEvents.EnemyHit evt)
    {
        AudioSource.PlayClipAtPoint(DroneHit, evt.enemy.transform.position, volume);
    }

    void droneDeath(GameEvents.EnemyDie evt)
    {
        AudioSource.PlayClipAtPoint(DroneDeath, evt.enemy.transform.position, volume);
    }

    void shootPaint(GameEvents.ShootPaint evt)
    {
        AudioSource.PlayClipAtPoint(ShootPaint, Vector3.zero, volume);
    }

    void shootProjectile(GameEvents.ShootProjectile evt)
    {
        AudioSource.PlayClipAtPoint(ShootProjectile, Vector3.zero, volume);
    }

    void paintEmpty(GameEvents.PaintEmpty evt)
    {
        AudioSource.PlayClipAtPoint(PaintEmpty, Vector3.zero, volume);
    }

    void ColorWheel (GameEvents.ColorWheelChange evt)
    {
        AudioSource.PlayClipAtPoint(colorWheel, Vector3.zero, volume);
    }

    void droneEnter(GameEvents.DroneWaveEnter evt)
    {
        AudioSource.PlayClipAtPoint(DroneEnter, Vector3.zero, volume);
    }

    void GameOver(GameEvents.GameOver evt)
    {
        AudioSource.PlayClipAtPoint(GameOverRiff, Vector3.zero, volume);
    }

    void StartDialogue (GameEvents.StartDialogue evt)
    {
        if (MarketTalking != null)
        {
            marketTalkingSource = Instantiate(AudioSourcePrefab);

            AudioSource source = marketTalkingSource.GetComponent<AudioSource>();
            source.clip = MarketTalking;
            source.Play();
        }
    }

    void EndDialogue (GameEvents.EndDialogue evt)
    {
        Destroy(marketTalkingSource);
    }
}
