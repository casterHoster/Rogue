using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VolumeRegulator))]

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

    private void OnTriggerEnter2D()
    {
            if (_isWork == false)
            {
                IEnumerator regulatingVolume = volumeRegulator.IncreaseVolume();
                RegulateVolume(true, regulatingVolume);
            }
            else
            {
                IEnumerator regulatingVolume = volumeRegulator.DecreaseVolume();
                RegulateVolume(false, regulatingVolume);
            }
        }

    private void RegulateVolume(bool isWork, IEnumerator changeVolume)
    {
        _isWork = isWork;
        volumeRegulator.StartCoroutine(changeVolume);
    }
}
