using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    Vector2 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move();
    }

    public void Move(Vector2 inputDirection)
    {
        Debug.Log("### PlayerController.Move: " + inputDirection.x + " / " + inputDirection.y);

        // move = Vector2.zero;
        inputDirection.y = 0;
        move = inputDirection;

        // ### Keyboard Input
        // Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            move += new Vector2(-1, 0);
        }

        // Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            move += new Vector2(1, 0);
        }

        move = move.normalized;

        // Flip Character
        if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (move.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }
}
