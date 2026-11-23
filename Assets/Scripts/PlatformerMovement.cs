using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    public Rigidbody2D rb2d;

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
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1, 1), 0, Vector2.zero);
        Debug.Log(hit.collider.name);

        return hit;
    }




    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            rb2d.linearVelocityY = jumpHeight;
        }



                                    

    }
}
