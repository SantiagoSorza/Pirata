using UnityEngine;

public class ActivarCollider : MonoBehaviour
{
    [SerializeField] private Collider colliderTeleport;

    public void HabilitarTeleport()
    {
        colliderTeleport.enabled = true;
    }
}
