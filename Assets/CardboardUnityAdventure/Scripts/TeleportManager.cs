using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance;
    public GameObject Player;

    [Header("Secuencia de teleports")]
    [Tooltip("Arrastrá los TeleportPoint EN ORDEN, del primero al último")]
    public List<GameObject> secuenciaTeleports;

    private int indiceActual = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < secuenciaTeleports.Count; i++)
        {
            secuenciaTeleports[i].SetActive(i == indiceActual);
        }
    }

    public void CompletarTeleport(GameObject teleportUsado)
    {
        teleportUsado.SetActive(false);
        indiceActual++;

        if (indiceActual < secuenciaTeleports.Count)
        {
            secuenciaTeleports[indiceActual].SetActive(true);
        }

#if UNITY_EDITOR
        Player.GetComponent<CardboardSimulator>().UpdatePlayerPositonSimulator();
#endif
    }
}