using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Patrol>(out Patrol patrol))
        {
            _reached?.Invoke();
        }
    }
}
