using UnityEngine;

public class InstruccionHUD : MonoBehaviour
{
    [SerializeField] private string mensaje = "Escribí acá la instrucción";

    public void Mostrar()
    {
        if (HUDManager.Instance != null)
            HUDManager.Instance.ActualizarInstruccionFija(mensaje);
    }
}
