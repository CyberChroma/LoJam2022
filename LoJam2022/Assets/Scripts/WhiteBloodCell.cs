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

    private void FixedUpdate() {
        gravity -= gravityDecreaseSpeed;
        if (gravity < 0) {
            gravity = 0;
        } else {
            rb.AddForce(Vector3.down * gravity);
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
            collision.collider.GetComponent<CellTypeManager>().CancerToBlood();
        }
    }
}
