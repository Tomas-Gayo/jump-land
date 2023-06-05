using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float xSpeed = 5.0f;
    [Header("Vertical Movement")]
    [SerializeField] private float jumpForce = 7.5f;
    [SerializeField] private float doubleJumpForce = 5.0f;
    [SerializeField] private float gravityFall = 2.5f;
    [SerializeField] private float gravityAscend = 2.0f;
    [SerializeField] private int totalJumps;

    [Header("Ground Information")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;

    [Header("Events")]
    [SerializeField] private UnityEvent onJump;
    [SerializeField] private UnityEvent onDoubleJump;
    // Inputs
    float moveX;
    bool canJump;
    public bool doubleJump = false;
    int jumps;

    // References
    Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start() => jumps = totalJumps;

    private void FixedUpdate()
    {
        GravityScale();
        Movement();
        if (IsGrounded()) jumps = totalJumps;
        if (canJump) Jump();
    }

    // ========== Player Physics ========== //
    private void Movement()
    {
        float xMovement = moveX * xSpeed;
        float yMovement = rb.velocity.y;

        rb.velocity = new Vector2(xMovement, yMovement);
    }

    private void Jump()
    {
        if (jumps == totalJumps)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onJump!.Invoke();

        }
        else
        {
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            onDoubleJump!.Invoke();
        }

        jumps--;
        canJump = false;
    }

    private void GravityScale()
    {
        if (rb.velocity.normalized.y < 0)
            rb.gravityScale = gravityFall;
        else if (rb.velocity.normalized.y > 0)
            rb.gravityScale = gravityAscend;
        else
            rb.gravityScale = 1.0f;
    }

    // ========== Player Inputs ========== //
    public void OnMove(InputAction.CallbackContext context) => moveX = context.ReadValue<Vector2>().x;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) canJump = CanJump();
    }

    // ========== Public methods ========== //

    public void AllowDoubleJump(bool enable) => doubleJump = enable;

    // ========== Private methods ========== //
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer);
    }

    bool CanJump()
    {
        // Can jump if is grounded
        if (IsGrounded()) return true;
        // ... or if the double jump is activated and extra jumps are available 
        else if (jumps > 0 && doubleJump) return true;
        // ... in the rest of cases canJump is false
        return false;
    }

    // ========== Gizmos ========== //
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

}
