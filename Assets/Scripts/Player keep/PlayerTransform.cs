using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerTransform : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite defaultSprite;      // 🖤
    public Sprite transformSprite;    // 💙

    [Header("Transform Duration")]
    public float transformDuration = 10f;

    [Header("Upgrade")]
    public float fireRateMultiplier = 0.4f;
    public bool enableTripleShot = true;
    public float speedBonus = 5f;


    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip transformClip;
    [SerializeField] private AudioClip revertClip;

    SpriteRenderer sr;
    PlayerShooter shooter;
    PlayerControl movement;

    float originalFireRate;
    float originalSpeed;

    Coroutine transformRoutine;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        shooter = GetComponent<PlayerShooter>();
        movement = GetComponent<PlayerControl>();

        originalFireRate = shooter.fireRate;
        originalSpeed = movement.speed;

        sr.sprite = defaultSprite;
    }

    // 🔥 เรียกเมื่อเก็บ Item
    public void ActivateTransform()
    {
        if (transformRoutine != null)
            StopCoroutine(transformRoutine);

        if (audioSource != null && transformClip != null)
            audioSource.PlayOneShot(transformClip);

        transformRoutine = StartCoroutine(TransformTimer());
    }


    IEnumerator TransformTimer()
    {
        // TRANSFORM
        sr.sprite = transformSprite;

        shooter.fireRate = originalFireRate * fireRateMultiplier;
        shooter.tripleShot = enableTripleShot;
        movement.speed = originalSpeed + speedBonus;

        yield return new WaitForSeconds(transformDuration);

        // REVERT
        sr.sprite = defaultSprite;

        if (audioSource != null && revertClip != null)
            audioSource.PlayOneShot(revertClip);

        shooter.fireRate = originalFireRate;
        shooter.tripleShot = false;
        movement.speed = originalSpeed;

        transformRoutine = null;
    }

}
