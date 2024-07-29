using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _playerAnimator;
    private bool _isGrounded;
    private bool _isFacingRight = true;

    public FlashlightController flashlightController;
    public KeyCode flashlightToggleKey = KeyCode.F;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _playerAnimator = _spriteRenderer.GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        var moveX = Input.GetAxis("Horizontal");

        var mousePosition = _camera!.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        bool shouldFaceRight = mousePosition.x > transform.position.x;

        // Flip the player sprite if necessary
        if (shouldFaceRight && !_isFacingRight || !shouldFaceRight && _isFacingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(flashlightToggleKey))
        {
            flashlightController.ToggleFlashlight();
            _playerAnimator.SetBool("isLightOn", flashlightController.flashlightEffect.activeSelf);
        }

        // Move the player
        _rb.velocity = new Vector2(moveX * speed, _rb.velocity.y);

        // Update the animator
        _playerAnimator.SetBool("isRunning", moveX != 0);

        // Make the player jump
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            SFXManager.Instance.PlayJumpSound();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}