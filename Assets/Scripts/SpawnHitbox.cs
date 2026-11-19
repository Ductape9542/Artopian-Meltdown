using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnHitbox : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public LayerMask attackLayer;

    private PlatformerMovement platformer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        platformer = GetComponent<PlatformerMovement>();
    }

    
    public void Attack(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + (Vector3)platformer.direction, attackRadius, Vector2.zero, 0, attackLayer );

        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)platformer.direction, attackRadius);
    }
}
