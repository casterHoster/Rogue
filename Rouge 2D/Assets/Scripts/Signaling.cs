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

<<<<<<< HEAD
=======
    private void Awake()
    {
        _volumeRegulator = GetComponent<VolumeRegulator>();
    }

    private void OnEnable()
    {
        _sensor.BorderIsReached += ControlSensorWork;
    }

>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
    public bool GetStatusWork()
    {
        return _isWork;
    }

<<<<<<< HEAD
    private void RegulateVolume()
=======
    private void ControlSensorWork()
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
    {
        _playing?.Invoke();
        RegulateVolume();
    }

    private void RegulateVolume()
    {
        if (_isWork == false)
        {
            _isWork = true;
<<<<<<< HEAD
            _volumeRegulator.StartCoroutine(_volumeRegulator.ChangeVolume(_maxVolume));
=======
            _volumeRegulator.StartCoroutine(_volumeRegulator.IncreaseVolume());
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
        }
        else
        {
            _isWork = false;
<<<<<<< HEAD
            _volumeRegulator.StartCoroutine(_volumeRegulator.ChangeVolume(_minVolume));
=======
            _volumeRegulator.StartCoroutine(_volumeRegulator.DecreaseVolume());
>>>>>>> 204880f63e5e622ad66a7906c97c569c8e2e496b
        }
    }
}
