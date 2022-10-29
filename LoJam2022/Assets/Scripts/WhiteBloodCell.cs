using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBloodCell : MonoBehaviour
{
    public float speed;
    public bool throwing;
    public float gravityDecreaseSpeed;
    public float gravity = 30;
    private Rigidbody rb;
    private Collider thisCollider;
    private Collider playerCollider;

    private float randRotationX = 0;
    private float randRotationY = 0;
    private float randRotationZ = 0;

    public void Throw(Collider player) {
        rb = GetComponent<Rigidbody>();
        thisCollider = GetComponent<Collider>();
        playerCollider = player;
        Physics.IgnoreCollision(thisCollider, playerCollider, true);
        throwing = true;
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        StartCoroutine(WaitToStopThrow());
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        thisCollider = GetComponent<Collider>();
        randRotationX = Random.Range(0f, 180f);
        randRotationY = Random.Range(0f, 180f);
        randRotationZ = Random.Range(0f, 180f);
    }

    void Update() {
        float xValue = (float)(0.5 * Mathf.Sin(randRotationX) + 0.5);
        float yValue = (float)(0.5 * Mathf.Cos(randRotationY) + 0.5);
        float zValue = (float)(0.5 * Mathf.Cos(randRotationZ) + 0.5);
        transform.Find("WhiteBloodCellModel").gameObject.transform.Rotate(new Vector3(xValue, yValue, zValue));
    }

    private void FixedUpdate() {
        gravity -= gravityDecreaseSpeed;
        if (gravity < 0) {
            gravity = 0;
        } else {
            if (rb) {
                rb.AddForce(Vector3.down * gravity);
            }
        }
    }

    IEnumerator WaitToStopThrow() {
        yield return new WaitForSeconds(1);
        Physics.IgnoreCollision(thisCollider, playerCollider, false);
        throwing = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.collider.CompareTag("Player")) {
            throwing = false;
        }
        if (collision.collider.CompareTag("Cancerous")) {
            if (rb) {
                rb.velocity = Vector3.zero;
            }
            collision.collider.GetComponent<CellTypeManager>().CancerToBlood();
        }
    }
}
