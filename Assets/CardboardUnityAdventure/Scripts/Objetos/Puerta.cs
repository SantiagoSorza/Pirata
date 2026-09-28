using UnityEngine;

public class PuertaControl : MonoBehaviour
{
    [SerializeField] private Collider colliderPuerta;

    public void HabilitarPuerta()
    {
        colliderPuerta.enabled = true;
    }
}