using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySystem
{
    public const string fileNameLight = "/lightData.dat";
    public const string fileNamePlayer = "/playerData.dat";
    public const string fileNameTimer = "/timerData.dat";

    public static void SaveLightData(LightData data)
    {
        string path = Application.persistentDataPath + fileNameLight;
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
            Debug.Log("Archivo de luz guardado correctamente");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar archivo de luz: " + e.Message);
        }
    }

    public static void SavePlayerData(PlayerData data)
    {
        string path = Application.persistentDataPath + fileNamePlayer;
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }
            Debug.Log("Archivo de jugador guardado correctamente");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar archivo de jugador: " + e.Message);
        }
    }

    public static void SaveTimerData(TimerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + fileNameTimer;
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LightData LoadLightData()
    {
        string path = Application.persistentDataPath + fileNameLight;
        if (!File.Exists(path))
        {
            Debug.LogWarning("No se encontró archivo de luz en " + path);
            return null;
        }

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(stream) as LightData;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar archivo de luz: " + e.Message);
            return null;
        }
    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + fileNamePlayer;
        if (!File.Exists(path))
        {
            Debug.LogWarning("No se encontró archivo de jugador en " + path);
            return null;
        }

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(stream) as PlayerData;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar archivo de jugador: " + e.Message);
            return null;
        }
    }

    public static TimerData LoadTimerData()
    {
        string path = Application.persistentDataPath + fileNameTimer;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            TimerData data = formatter.Deserialize(stream) as TimerData;
            stream.Close();
            return data;
        }
        return null;
    }
}
