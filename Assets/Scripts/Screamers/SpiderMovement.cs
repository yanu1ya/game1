using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Transform _transform;
    [SerializeField] BoxCollider2D _boxCollider;
    bool _triggered;
    float speed = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _triggered = true;
        _audioSource.Play();
        _boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_triggered && _transform.position.y > -17)
        {
            _transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
