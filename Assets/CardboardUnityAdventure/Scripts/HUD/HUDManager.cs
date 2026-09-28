using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private GameObject panelInstrucciones;
    [SerializeField] private TMP_Text textoInstruccion;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MostrarInstruccion("Interactúa con las monedas para moverte", 5f);
    }

    public void MostrarInstruccion(string mensaje, float duracion = 3f)
    {
        textoInstruccion.text = mensaje;
        panelInstrucciones.SetActive(true);
        CancelInvoke(nameof(OcultarInstruccion));
        Invoke(nameof(OcultarInstruccion), duracion);
    }

    public void ActualizarInstruccionFija(string mensaje)
    {
        CancelInvoke(nameof(OcultarInstruccion));
        textoInstruccion.text = mensaje;
        panelInstrucciones.SetActive(true);
    }

    private void OcultarInstruccion()
    {
        panelInstrucciones.SetActive(false);
    }
}