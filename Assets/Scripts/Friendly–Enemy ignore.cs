using UnityEngine;

public class FriendlyCollisionFix : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(
            LayerMask.NameToLayer("Friendly"),
            LayerMask.NameToLayer("Enemy"),
            true
        );
    }
}
