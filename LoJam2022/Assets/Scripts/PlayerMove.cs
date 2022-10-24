using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float smoothing;
    public float speed;
    public Transform cam;

    private float forward = 0;
    private float horizontal = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            forward = Mathf.Lerp(forward, 1, smoothing * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.S)) {
            forward = Mathf.Lerp(forward, -1, smoothing * Time.deltaTime);
        } else {
            forward = Mathf.Lerp(forward, 0, smoothing * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            horizontal = Mathf.Lerp(horizontal, 1, smoothing * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) {
            horizontal = Mathf.Lerp(horizontal, -1, smoothing * Time.deltaTime);
        } else {
            horizontal = Mathf.Lerp(horizontal, 0, smoothing * Time.deltaTime);
        }

        Vector3 moveVector = cam.forward * forward + cam.right * horizontal;
        rb.AddForce(moveVector * speed);
    }
}