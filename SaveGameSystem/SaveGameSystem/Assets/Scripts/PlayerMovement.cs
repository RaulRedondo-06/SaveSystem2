using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : ObjecteGuardable, IInitializable
{
    public static PlayerMovement instance;

    [SerializeField] private InputActionAsset movementMap;
    [SerializeField] private InputAction movementAction;

    private Rigidbody rb;
    private float xVel, zVel;
    private Vector3 movementVector;
    private PlayerData playerData = new PlayerData();

    private void Awake()
    {
        playerData = BinarySystem.LoadPlayerData();

        if (playerData == null) { playerData = new PlayerData(); }
        else { LoadData(); }
    }

    void Start()
    {
        LoadManager.instance.Register(this);
    }

    public void Init()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        movementMap.Enable();

        movementAction = movementMap.FindActionMap("Player").FindAction("Move");
        movementAction.Enable();

        movementAction.performed += Movement;
        rb = GetComponent<Rigidbody>();

        
    }

    void Update()
    {
        transform.Translate(movementVector, Space.Self);
    }

    private void Movement(InputAction.CallbackContext ctx)
    {
        Vector2 vector = ctx.ReadValue<Vector2>();
        Vector3 vector3 = new Vector3(vector.x, 0, vector.y);
        movementVector = vector3;
    }

    public override void SaveData()
    {
        playerData.posX = transform.position.x;
        playerData.posY = transform.position.y;
        playerData.posZ = transform.position.z;

        BinarySystem.SavePlayerData(playerData);
        Debug.Log("PlayerData saved, pos: " + playerData.posX + " " + playerData.posY + " " + playerData.posZ);
    }

    public override void LoadData()
    {
        Vector3 positionLoaded = new Vector3(playerData.posX, playerData.posY, playerData.posZ);
        transform.position = positionLoaded;
        Debug.Log("PlayerData loaded, positionLoaded: " + positionLoaded);
    }
}
