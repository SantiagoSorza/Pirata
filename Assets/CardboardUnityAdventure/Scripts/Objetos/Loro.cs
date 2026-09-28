using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Loro : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string tipoQueAcepta = "Galleta";
    [SerializeField] private AudioClip sonidoComer;
    [SerializeField] private Transform posicionAlLadoDelJugador;
    [SerializeField] private float duracionAnimacionComer = 0.3f;

    [Header("Eventos")]
    public UnityEvent OnAlimentado; // NUEVO

    private AudioSource audioSource;
    private bool yaAlimentado = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnPointerEnterXR() { }
    public void OnPointerExitXR() { }

    public void OnPointerClickXR()
    {
        if (yaAlimentado) return;

        GameObject item = GrabManager.Instance.heldItem;
        if (item == null) return;

        GrabObject grabObj = item.GetComponent<GrabObject>();
        if (grabObj == null || !grabObj.type.Equals(tipoQueAcepta)) return;

        grabObj.Delete();
        StartCoroutine(ComerYSeguir());
    }

    private IEnumerator ComerYSeguir()
    {
        yaAlimentado = true;

        if (sonidoComer != null)
            audioSource.PlayOneShot(sonidoComer);

        yield return new WaitForSeconds(duracionAnimacionComer);

        if (posicionAlLadoDelJugador != null)
        {
            transform.SetParent(posicionAlLadoDelJugador, false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        DontDestroyOnLoad(gameObject); // NUEVO: persiste desde que se monta

        OnAlimentado?.Invoke();
    }
    
}