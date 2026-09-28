using UnityEngine;

public class Voces : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoInteraccion;
    [SerializeField] private bool sonarUnaSolaVez = false;

    private AudioSource audioSource;
    private bool yaSono = false;

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
        if (sonarUnaSolaVez && yaSono) return;

        if (sonidoInteraccion != null)
        {
            audioSource.PlayOneShot(sonidoInteraccion);
            yaSono = true;
        }
    }
}
