using UnityEngine;
using UnityEngine.SceneManagement;

public class Aparicion : MonoBehaviour
{
    [SerializeField] private Transform puntoSpawn;

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
        GameObject player = TeleportManager.Instance.Player;
        if (player == null || puntoSpawn == null) return;

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        player.transform.position = puntoSpawn.position;
        player.transform.rotation = puntoSpawn.rotation;

        if (cc != null) cc.enabled = true;
    }
}
