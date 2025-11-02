using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private LightScript lightObject;
    [SerializeField] private TimerScript timer;

    public void GuardarJuego()
    {
        if (player != null) player.SaveData();
        if (lightObject != null) lightObject.SaveData();
        if (timer != null) timer.SaveData();
        Debug.Log("Juego guardado correctamente");
    }


    public void CargarJuego()
    {
        if (player != null) player.LoadData();
        if (lightObject != null) lightObject.LoadData();
        if (timer != null) timer.LoadData(); 
        Debug.Log("Juego cargado correctamente");
    }

}
