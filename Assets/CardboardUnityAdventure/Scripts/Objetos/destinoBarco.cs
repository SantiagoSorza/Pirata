using UnityEngine;
using UnityEngine.Events;

public class DestinoBarco : MonoBehaviour
{
    [SerializeField] private GameObject barcoObjeto;
    public UnityEvent OnBarcoDetenido;

    private BarcoMov barco;

    private void Start()
    {
        if (barcoObjeto != null)
        {
            barco = barcoObjeto.GetComponent<BarcoMov>();
            if (barco == null) barco = barcoObjeto.GetComponentInParent<BarcoMov>();
            if (barco == null) barco = barcoObjeto.GetComponentInChildren<BarcoMov>();
        }

        if (barco == null)
        {
            Debug.LogWarning("DestinoBarco: no se encontró el componente BarcoMov en el objeto asignado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (barco == null) return;

        BarcoMov barcoDetectado = other.GetComponent<BarcoMov>();
        if (barcoDetectado == null) barcoDetectado = other.GetComponentInParent<BarcoMov>();

        if (barcoDetectado == null || barcoDetectado != barco) return;

        barco.LlegoADestino = true;
        OnBarcoDetenido?.Invoke();
    }
}