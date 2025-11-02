using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class TimerScript : ObjecteGuardable
{
    public TimerData timerData = new TimerData();
    public TextMeshProUGUI timerText;
    private float tiempo;

    private void Awake()
    {
        timerData = BinarySystem.LoadTimerData();
        if (timerData == null)
        {
            timerData = new TimerData();
        }
        else
        {
            LoadData();
        }
    }

    private void Update()
    {
        tiempo += Time.deltaTime;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        if (timerText != null)
        {
            int minutos = (int)(tiempo / 60);
            int segundos = (int)(tiempo % 60);
            timerText.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        }
    }

    public override void SaveData()
    {
        timerData.tiempoTranscurrido = tiempo;
        BinarySystem.SaveTimerData(timerData);
        Debug.Log("Cronómetro guardado: " + tiempo);
    }

    public override void LoadData()
    {
        tiempo = timerData.tiempoTranscurrido;
        ActualizarTexto();
        Debug.Log("Cronómetro cargado: " + tiempo);
    }
}
