using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _gunner;
    [SerializeField] private float _timeWait;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeWait);

        while (true)
        {
            var direction = (_target.position - transform.position).normalized;
            Rigidbody2D bullet = Instantiate(_gunner, transform.position + direction, Quaternion.identity);
            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;
            yield return wait;
        }
    }
}