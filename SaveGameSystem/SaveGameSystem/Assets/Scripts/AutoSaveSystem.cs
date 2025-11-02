using UnityEngine;

public class AutoSaveSystem : MonoBehaviour
{
    public static AutoSaveSystem instance;
    public const float TIME_TO_AUTOSAVE = 5f;
    private float timeElapsed;

    [SerializeField] private LightScript lightScript;
    [SerializeField] private TimerScript timerScript; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        AutoSave();
    }

    private void AutoSave()
    {
        if (timeElapsed < TIME_TO_AUTOSAVE)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            PlayerMovement.instance.SaveData();

            if (lightScript != null) lightScript.SaveData();
            if (timerScript != null) timerScript.SaveData();

            timeElapsed = 0;

            Debug.Log("AutoSave ejecutado correctamente");
        }
    }

}
