
using UnityEngine;

public class DestructibleStructure : MonoBehaviour
{
    public float captureTime = 5f;
    private float progress = 0f;

    private bool playerInside = false;
    private bool completed = false;
    public GameObject dropItemPrefab;
    public Transform dropPoint;
    public CameraShake cameraShake;
    public float shakeIntensity = 0.1f;
    Vector3 originalLocalPos;
    [SerializeField] private AudioSource soundCapture;
    void Start()
    {
        originalLocalPos = transform.localPosition;
        soundCapture = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (playerInside)
        {
            progress += Time.deltaTime;

            if (!soundCapture.isPlaying)
                soundCapture.Play();

            ShakeStructure();

            if (progress >= captureTime)
            {
                CompleteCapture();
            }
        }
        else
        {
            if (soundCapture.isPlaying)
                soundCapture.Stop();

            progress = Mathf.Max(0, progress - Time.deltaTime);
            ResetPosition();
        }
    }
    void ShakeStructure()
    {
        Vector3 offset = Random.insideUnitSphere * shakeIntensity;
        offset.y = 0; // ถ้าไม่อยากให้ลอยขึ้นลง
        transform.localPosition = originalLocalPos + offset;
    }

    void ResetPosition()
    {
        transform.localPosition = originalLocalPos;
    }

    void CompleteCapture()
    {
        completed = true;

        ResetPosition(); // ✅ กลับตำแหน่งก่อนพัง

        GiveReward();
        PlayDestroyEffect();

        Destroy(gameObject, 0.2f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    void GiveReward()
    {
        if (dropItemPrefab != null)
        {
            Instantiate(
                dropItemPrefab,
                dropPoint != null ? dropPoint.position : transform.position,
                Quaternion.identity
            );
        }
    }

    void PlayDestroyEffect()
    {
        // particle / sound / animation

    }
    // gpt gen ล้วนๆเน้อ
}
