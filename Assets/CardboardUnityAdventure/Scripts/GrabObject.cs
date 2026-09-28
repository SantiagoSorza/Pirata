using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrabObject : MonoBehaviour
{
    GrabManager grabManager;
    BoxCollider boxCollider;
    Vector3 spawnerPosition;
    Quaternion spawnerRotation;

    public AudioClip soundGrab;
    public AudioClip soundPlace;

    [SerializeField] public string type = "Objeto";
    [SerializeField] public GameObject spawner;

    [Header("Eventos")]
    public UnityEvent OnGrabbed; // NUEVO

    private AudioSource player;

    void Start()
    {
        player = GetComponent<AudioSource>();
        spawnerPosition = spawner.transform.position;
        spawnerRotation = spawner.transform.rotation;
        boxCollider = GetComponent<BoxCollider>();
        grabManager = GrabManager.Instance;
    }

    public void Grab()
    {
        if (player != null && soundGrab != null)
            player.PlayOneShot(soundGrab);

        if (grabManager.heldItem != null)
        {
            grabManager.heldItem.GetComponent<GrabObject>().Drop();
        }
        grabManager.heldItem = transform.gameObject;
        boxCollider.enabled = false;

        OnGrabbed?.Invoke(); // NUEVO: avisa que se agarró
    }

    public void Drop()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void Delete()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(false);
    }

    public void Respawn()
    {
        transform.position = spawnerPosition;
        transform.rotation = spawnerRotation;
        boxCollider.enabled = true;
        transform.gameObject.SetActive(true);
    }

    public void Place(Vector3 position)
    {
        if (player != null && soundPlace != null)
            player.PlayOneShot(soundPlace);
        transform.position = position;
        grabManager.heldItem = null;
        boxCollider.enabled = true;
    }

    public void OnPointerClickXR()
    {
        Grab();
    }
}