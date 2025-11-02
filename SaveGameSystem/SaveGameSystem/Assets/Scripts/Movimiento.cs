using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float fuerzaSalto = 5f; 

    private Rigidbody rb;
    private bool enSuelo = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.contacts[0].normal.y > 0.5f)
        {
            enSuelo = true;
        }
    }
}
