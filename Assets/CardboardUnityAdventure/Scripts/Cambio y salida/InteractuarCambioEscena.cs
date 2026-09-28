using UnityEngine;

public class InteractuarCambioEscena : MonoBehaviour
{
    [SerializeField] private CambiodeEscena cambiadorEscena;
    [SerializeField] private int numeroEscena;

    public void OnPointerEnterXR() { }
    public void OnPointerExitXR() { }

    public void OnPointerClickXR()
    {
        cambiadorEscena.CambiarEscena(numeroEscena);
    }
}