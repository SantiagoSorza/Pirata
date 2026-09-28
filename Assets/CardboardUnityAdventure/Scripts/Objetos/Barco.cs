using UnityEngine;

public class MovimientoBarco : MonoBehaviour
{
    public float velocidad = 3f;
    public bool EstaControlando = false;
    public bool LlegoADestino = false; 

    void Update()
    {
        if (EstaControlando && !LlegoADestino)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }
}