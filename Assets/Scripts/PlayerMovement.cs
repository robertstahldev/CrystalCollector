using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    //Arena movement bounds.
    [SerializeField] private Vector2 arenaLimits = new (6.7f, 3.7f);

    private Rigidbody2D rb;
    private Vector2 movement;

    //Starting position for resets.
    private Vector2 startingPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
    }

    private void Update()
    {
        //Reset game and player position.
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.ResetGame();
            rb.position = startingPosition;
        }

        //Disable movement after victory.
        if (GameManager.Instance.CurrentState != GameManager.GameState.Playing)
        {
            movement = Vector2.zero;
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        Vector2 nextPosition =
            rb.position + moveSpeed * Time.fixedDeltaTime * movement;

        //Clamp movement to arena bounds.
        nextPosition.x = Mathf.Clamp(
            nextPosition.x, -arenaLimits.x, arenaLimits.x);

        nextPosition.y = Mathf.Clamp(
            nextPosition.y, -arenaLimits.y, arenaLimits.y);

        rb.MovePosition(nextPosition);
    }
}