using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool loop = false;
    [SerializeField] private bool soloUnaVez = false;

    private AudioSource audioSource;
    private bool yaSono = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Reproducir()
    {
        if (soloUnaVez && yaSono) return;
        if (clip == null) return;

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
        yaSono = true;
    }

    public void Detener()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
