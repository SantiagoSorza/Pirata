using UnityEngine;

public class BarcoMov : MonoBehaviour
{
    public float velocidad = 3f;
    public bool LlegoADestino = false;
    public bool EmpezarMoviendoseAlIniciar = false;

    void Start()
    {
 
    }

    void Update()
    {
        if (!LlegoADestino)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

}
