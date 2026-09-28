using UnityEngine;

public class mensajeInicial : MonoBehaviour
{
 
    [SerializeField] private string mensaje = "Sigue interatuando el camino de las monedas";
    private float duracion = 5f;

    private void Start()
    {
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.MostrarInstruccion(mensaje, duracion);
        }
    }
}

