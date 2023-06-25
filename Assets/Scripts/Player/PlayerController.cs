using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Physical characteristics")]
    [SerializeField] public float Speed;
    [SerializeField] public float JumpForce;
    
    private float _horizontal, _vertical;

    [Header("Advanced Jump characteristics")]
    public float JumpTime; // hold to jump higher
    public float JumpInterval; // jump inverval after landing

    private bool _isJumping;
    private float _jumpInvervalCounter;
    private float _jumpTimeCounter;
    private bool _jumpReleased; // double jump avoidance

    [Header("Components")]
    [SerializeField] private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    [SerializeField] private Transform _respawnPoint;
    [SerializeField] private ParticleSystem _deathBurstParticles;
    [SerializeField] private DeathScene _deathscene;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _deathMusic;

    // Start is called before the first frame update
    void Start()
    {
        _isJumping = true;
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleKeyboardInput();
        UpdateVariables();
    }

    // Fixed is called every fixed framerate frame
    private void FixedUpdate()
    {
        HandleRunning();
        HandleJumping();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destination"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsGrounded", true);
            _isJumping = false;
            _jumpInvervalCounter = JumpInterval;
            //_jumpReleased = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("IsGrounded", false);
            _isJumping = true;
        }
    }

    private IEnumerator HandleDeath()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        _sr.color = new Color(_sr.color.r, _sr.color.g, _sr.color.b, 0);
        _backgroundMusic.Stop();
        _deathMusic.Play();
        _deathBurstParticles.Play();
        yield return new WaitForSeconds(1f);
        _deathscene.SetUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if we collided with anything in the harmful layer, death occurs
        if (collision.gameObject.CompareTag("Harmful"))
        {
            StartCoroutine(HandleDeath());
        }
    }

    private void HandleKeyboardInput()
    {
        _horizontal = SimpleInput.GetAxis("Horizontal");
        _vertical = SimpleInput.GetAxis("Vertical");
    }

    private void UpdateVariables()
    {
        _animator.SetFloat("HorizontalSpeed", Mathf.Abs(_horizontal));
        _animator.SetFloat("VerticalSpeed", _rb.velocity.y);

        if (_rb.velocity.y > 0.01f && _vertical < 0.01f)
            _jumpReleased = true;

        else if (!_isJumping && _jumpInvervalCounter > 0f)
            _jumpInvervalCounter -= Time.deltaTime;
    }

    private void HandleRunning()
    {
        if (_horizontal > 0.1f || _horizontal < -0.1f)
            _rb.velocity = new Vector2(_horizontal * Speed, _rb.velocity.y);
    }

    private void HandleJumping()
    {
        if (!_isJumping && _vertical > 0.1f && _jumpInvervalCounter <= 0f)
        {
            _jumpTimeCounter = JumpTime;
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
            _jumpReleased = false;
        }

        else if (_vertical > 0.1f && _jumpTimeCounter > 0f && !_jumpReleased)
        {
            _jumpTimeCounter -= Time.deltaTime;
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
        }
    }
}
