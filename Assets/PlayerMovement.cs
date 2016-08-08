using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
  public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour {
  public float speed;
  public float tilt;
  public Boundary boundary;
  private Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
    rb.velocity = movement * speed;

    rb.position = new Vector3(
      Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
      Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
      0.0f
    );
  }
}
