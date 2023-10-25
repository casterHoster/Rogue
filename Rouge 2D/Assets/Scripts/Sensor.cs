using System;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public event Action BorderIsReached;
    public event Action BorderIsLeft;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Patrol>(out Patrol patrol))
        {
            BorderIsReached?.Invoke();
        }
    }
}
