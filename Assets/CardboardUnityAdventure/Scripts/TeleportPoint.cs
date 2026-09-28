using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    [SerializeField] private Transform spawnPoint;

    public void OnPointerEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }

    public void OnPointerClickXR()
    {
        ExecuteTeleportation();
        OnTeleport?.Invoke();
        TeleportManager.Instance.CompletarTeleport(gameObject);
    }

    public void OnPointerExitXR()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleportation()
    {
        GameObject player = TeleportManager.Instance.Player;
        CharacterController cc = player.GetComponent<CharacterController>();
        Camera camera = player.GetComponentInChildren<Camera>();

        if (cc != null) cc.enabled = false;

        Vector3 offsetCamara = camera.transform.position - player.transform.position;
        offsetCamara.y = 0;

        player.transform.position = spawnPoint.position - offsetCamara;

        //float rotY = spawnPoint.rotation.eulerAngles.y - camera.transform.localEulerAngles.y;
        //player.transform.rotation = Quaternion.Euler(0, rotY, 0);

        if (cc != null) cc.enabled = true;
    }
}