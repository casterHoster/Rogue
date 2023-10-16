using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    private bool _isWork;
    private VolumeRegulator volumeRegulator;

    public bool GetStatusWork()
    {
        return _isWork;
    }

    private void Start()
    {
        volumeRegulator = GetComponent<VolumeRegulator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Patrol>(out Patrol patrol))
        {
            _reached?.Invoke();

            if (_isWork == false)
            {
                _isWork = true;
                volumeRegulator.StartCoroutine(volumeRegulator.IncreaseVolume());
            }
            else
            {
                _isWork = false;
                volumeRegulator.StartCoroutine(volumeRegulator.DecreaseVolume());
            }
        }
    }
}
