using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeRegulator))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _playing;
    [SerializeField] private Sensor _sensor;

    private bool _isWork;
    private VolumeRegulator _volumeRegulator;

    private void Awake()
    {
        _volumeRegulator = GetComponent<VolumeRegulator>();
    }

    private void OnEnable()
    {
        _sensor.BorderIsReached += ControlSensorWork;
    }

    public bool GetStatusWork()
    {
        return _isWork;
    }

    private void ControlSensorWork()
    {
        _playing?.Invoke();
        RegulateVolume();
    }

    private void RegulateVolume()
    {
        if (_isWork == false)
        {
            _isWork = true;
            _volumeRegulator.StartCoroutine(_volumeRegulator.IncreaseVolume());
        }
        else
        {
            _isWork = false;
            _volumeRegulator.StartCoroutine(_volumeRegulator.DecreaseVolume());
        }
    }
}
