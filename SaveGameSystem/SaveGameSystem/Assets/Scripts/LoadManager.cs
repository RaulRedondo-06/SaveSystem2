using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    private List<IInitializable> initializableObjects = new List<IInitializable>();

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        StartCoroutine(InitializeObjects());
    }

    private IEnumerator InitializeObjects()
    {
        yield return new WaitForSeconds(0.1f);
        foreach(var obj in initializableObjects)
        {
            obj.Init();
        }

        initializableObjects.Clear();
    }

    public void Register(IInitializable obj)
    {
        initializableObjects.Add(obj);
    }
}
