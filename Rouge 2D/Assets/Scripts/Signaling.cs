using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeRegulator))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _playing;
    [SerializeField] private Sensor _sensor;

    private bool _isWork;
    private VolumeRegulator _volumeRegulator;

    public bool GetStatusWork()
    {
        return _isWork;
    }

    private void Awake()
    {
        _volumeRegulator = GetComponent<VolumeRegulator>();
    }

    private void OnEnable()
    {
        _sensor.BorderIsReached += ControlSensorWork;
    }

    private void ControlSensorWork()
    {
        _playing?.Invoke();

        if (_isWork == false)
        {
            IEnumerator regulatingVolume = _volumeRegulator.IncreaseVolume();
            RegulateVolume(true, regulatingVolume);
        }
        else
        {
            IEnumerator regulatingVolume = _volumeRegulator.DecreaseVolume();
            RegulateVolume(false, regulatingVolume);
        }
    }

    private void RegulateVolume(bool isWork, IEnumerator changeVolume)
    {
        _isWork = isWork;
        _volumeRegulator.StartCoroutine(changeVolume);
    }
}
