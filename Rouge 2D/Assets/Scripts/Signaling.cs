using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeRegulator))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _playing;
    [SerializeField] private Sensor _sensor;

    private Coroutine _increasingVolume;
    private Coroutine _decreasingVolume;
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

    private void RegulateVolume()
    {
        _playing?.Invoke();

        if (_isWork == false)
        {
            _isWork = true;
            _increasingVolume = StartCoroutine(_volumeRegulator.ChangeVolume(_maxVolume));

            if (_decreasingVolume != null) 
            {
                StopCoroutine(_decreasingVolume);
            }
        }
        else
        {
            _isWork = false;
            _decreasingVolume = StartCoroutine(_volumeRegulator.ChangeVolume(_minVolume));
            StopCoroutine(_increasingVolume);

            if (_increasingVolume != null)
            {
                StopCoroutine(_increasingVolume);
            }
        }
    }
}
