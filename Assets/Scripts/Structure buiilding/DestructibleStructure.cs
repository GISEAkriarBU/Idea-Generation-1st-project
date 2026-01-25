using UnityEngine;

public class DestructibleStructure : MonoBehaviour
{
    public float captureTime = 5f;
    private float progress = 0f;

    private bool playerInside = false;
    private bool completed = false;

    void Update()
    {
        if (completed) return;

        if (playerInside)
        {
            progress += Time.deltaTime;

            if (progress >= captureTime)
            {
                CompleteCapture();
            }
        }
        else
        {
            progress = Mathf.Max(0, progress - Time.deltaTime);
        }
    }

    void CompleteCapture()
    {
        completed = true;

        // 1. ให้รางวัล
        GiveReward();

        // 2. เอฟเฟกต์พัง
        PlayDestroyEffect();

        // 3. ทำลาย structure
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
        // drop item / buff / currency
    }

    void PlayDestroyEffect()
    {
        // particle / sound / animation 

    }
    // gpt gen ล้วนๆเน้อ
}
