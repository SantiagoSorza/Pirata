using UnityEngine;

public class TriggerCambioEscena : MonoBehaviour
{
    [SerializeField] private CambiodeEscena cambiadorEscena;
    [SerializeField] private int numeroEscena;
    [SerializeField] private string tagRequerido = "Destino";

    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(tagRequerido) && !other.CompareTag(tagRequerido)) return;

        cambiadorEscena.CambiarEscena(numeroEscena);
    }
}