using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed = 3;
    public float inputSmoothing = 10;
    public float dashSpeed = 25;
    public float dashDelay = 0.75f;
    public Transform cam;

    private float forward = 0;
    private float horizontal = 0;
    private bool canDash = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            forward = Mathf.Lerp(forward, 1, inputSmoothing * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            forward = Mathf.Lerp(forward, -1, inputSmoothing * Time.deltaTime);
        } else {
            forward = Mathf.Lerp(forward, 0, inputSmoothing * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            horizontal = Mathf.Lerp(horizontal, 1, inputSmoothing * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) {
            horizontal = Mathf.Lerp(horizontal, -1, inputSmoothing * Time.deltaTime);
        } else {
            horizontal = Mathf.Lerp(horizontal, 0, inputSmoothing * Time.deltaTime);
        }

        Vector3 moveVector = cam.forward * forward + cam.right * horizontal;
        rb.AddForce(moveVector * speed);

        if (canDash && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(moveVector * dashSpeed, ForceMode.Impulse);
            StartCoroutine(WaitToDash());
        }
    }

    IEnumerator WaitToDash() {
        canDash = false;
        yield return new WaitForSeconds(dashDelay);
        canDash = true;
    }
}