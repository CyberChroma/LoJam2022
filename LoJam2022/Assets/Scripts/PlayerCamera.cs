using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    public float turnHorizontalSpeed = 4;
    public float turnVerticalSpeed = 3;
    public float minXTurn = -85;
    public float maxXTurn = 45;

    private float mouseX;
    private float mouseY;
    private float XChange;
    private float YChange;
    private float newXRot;
    private float newYRot;

    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        Turn();
    }

    void Turn() {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        XChange = -mouseY * turnVerticalSpeed * Time.timeScale;
        newXRot = transform.rotation.eulerAngles.x + XChange;
        if (newXRot > 180) {
            newXRot = Mathf.Clamp(newXRot, minXTurn + 360, 370);
        } else {
            newXRot = Mathf.Clamp(newXRot, -10, maxXTurn);
        }

        YChange = mouseX * turnHorizontalSpeed * Time.timeScale;
        newYRot = transform.rotation.eulerAngles.y + YChange;

        Vector3 newRotation = new Vector3(newXRot, newYRot, 0);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}