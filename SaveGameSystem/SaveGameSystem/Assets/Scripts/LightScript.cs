using UnityEngine;

public class LightScript : ObjecteGuardable, IInitializable
{
    public LightData lightData;
    [SerializeField] private Material lightMat;

    private void Awake()
    {
        lightData = BinarySystem.LoadLightData();

        if (lightData == null) { lightData = new LightData(); }
        else { LoadData(); }
    }

    void Start()
    {
        LoadManager.instance.Register(this);
    }

    public void Init()
    {
        if (lightData == null)
            lightMat.color = Color.white;
    }

    public void ChangeColorRed()
    {
        lightMat.color = Color.red;
    }

    public void ChangeColorBlue()
    {
        lightMat.color = Color.blue;
    }

    public override void SaveData()
    {
        lightData.rCol = lightMat.color.r;
        lightData.gCol = lightMat.color.g;
        lightData.bCol = lightMat.color.b;
        lightData.alpha = lightMat.color.a;
        BinarySystem.SaveLightData(lightData);
    }

    public override void LoadData()
    {
        lightData = BinarySystem.LoadLightData();
        Vector4 loadedColor = new Vector4(lightData.rCol, lightData.gCol, lightData.bCol, lightData.alpha);
        lightMat.color = loadedColor;
    }
}
