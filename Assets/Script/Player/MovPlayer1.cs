using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        float moveVertical = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
