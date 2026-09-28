using UnityEngine;

public class Timon : MonoBehaviour
{
    public MovimientoBarco barco;

   
    public void OnPointerEnterXR()
    {
       
    }
    public void OnPointerExitXR()
    {
    }

    public void OnPointerClickXR()
    {
        ActivarTimon();
    }

    void ActivarTimon()
    {
        barco.EstaControlando = true;
    }
}