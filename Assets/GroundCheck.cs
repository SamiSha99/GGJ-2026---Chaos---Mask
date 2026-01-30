using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Collider2D feetCollider;
    public LayerMask groundLayer;

    private readonly Collider2D[] hits = new Collider2D[8];

    public bool IsGrounded { get; private set; }

    void Update()
    {
        if (feetCollider == null) return;

        ContactFilter2D filter = new ContactFilter2D();
        filter.useLayerMask = true;
        filter.layerMask = groundLayer;
        filter.useTriggers = false; 

        int count = feetCollider.Overlap(filter, hits);
        IsGrounded = count > 0;
    }
}
