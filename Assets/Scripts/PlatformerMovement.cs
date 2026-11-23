using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D),typeof(PlayerInput))]
public class PlatformerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] Vector2 _boxOffset;
    [SerializeField] Vector2 _boxSize;
    [SerializeField] LayerMask _boxLayer;
    private Rigidbody2D rb2d;

 private float _movement;
    internal Vector3 movement;
   
    [HideInInspector] public Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityX = _movement;
    }



    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * moveSpeed;

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            direction = ctx.ReadValue<Vector2>();
        }
      
    }
    private bool IsGrounded()
    {
        // Check for the ground using a boxcast
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)_boxOffset, _boxSize, 0, Vector2.zero, 0, _boxLayer);
      

        return hit;
    }




    public void Jump(InputAction.CallbackContext ctx)
    {
        
        {
            if (ctx.canceled || !IsGrounded())
                return;
            
             rb2d.linearVelocityY = jumpHeight;
        }



                                    
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)_boxOffset, _boxSize);
    }
}
