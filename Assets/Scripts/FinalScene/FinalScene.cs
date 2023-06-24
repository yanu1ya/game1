using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] CircleCollider2D _collider;
    [SerializeField] Rigidbody2D _playerRB;
    [SerializeField] Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        gameObject.SetActive(false);
        _playerRB.bodyType = RigidbodyType2D.Static;
        _animator.SetBool("IsEnd", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
