using UnityEngine;

public class TimedDisappear : MonoBehaviour
{
    public float lifetime = 3f;

    void OnEnable()
    {
        CancelInvoke(); // just in case
        Invoke(nameof(Hide), lifetime);
    }

    void Hide()
    {
        if (TryGetComponent<SpriteRenderer>(out var renderer))
            renderer.enabled = false;

        if (TryGetComponent<Collider2D>(out var collider))
            collider.enabled = false;
    }
}