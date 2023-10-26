using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeRegulator))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _playing;
    [SerializeField] private Sensor _sensor;

    private VolumeRegulator _volumeRegulator;
    private float _minVolume;
    private float _maxVolume;
    private bool _isWork;

    private void Awake()
    {
        _volumeRegulator = GetComponent<VolumeRegulator>();
        _minVolume = 0;
        _maxVolume = 1;
    }

    private void OnEnable()
    {
        _sensor.BorderIsReached += RegulateVolume;
    }

    public bool GetStatusWork()
    {
        return _isWork;
    }

    private void RegulateVolume()
    {
        _playing?.Invoke();

        if (_isWork == false)
        {
            _isWork = true;
            _volumeRegulator.StartCoroutine(_volumeRegulator.ChangeVolume(_maxVolume));
        }
        else
        {
            _isWork = false;
            _volumeRegulator.StartCoroutine(_volumeRegulator.ChangeVolume(_minVolume));
        }
    }
}
