using UnityEngine;
using System.Collections;

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

        transformRoutine = StartCoroutine(TransformTimer());
    }

    IEnumerator TransformTimer()
    {
        // ===== TRANSFORM =====
        sr.sprite = transformSprite;

        shooter.fireRate = originalFireRate * fireRateMultiplier;
        shooter.tripleShot = enableTripleShot;

        movement.speed = originalSpeed + speedBonus;

        yield return new WaitForSeconds(transformDuration);

        // ===== BACK TO DEFAULT =====
        sr.sprite = defaultSprite;

        shooter.fireRate = originalFireRate;
        shooter.tripleShot = false;

        movement.speed = originalSpeed;

        transformRoutine = null;
    }
}
