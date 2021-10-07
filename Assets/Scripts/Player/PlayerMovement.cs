using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float height = 4f;
    [SerializeField] private float highJump = 6f;
    [SerializeField] private float jumpTime = 2f;

    [Header("Local")]
    private PlayerCollision playerCollision;
    private float timer;
    private bool isJumping;

    private void Awake() => playerCollision = GetComponent<PlayerCollision>();

    private void FixedUpdate() => Timer();

    public void ClickJump()
    {
        if (!isJumping)
        {
            isJumping = true;
            timer = jumpTime;
        }
    }

    private void Moving(Vector3 vector3)
    {
        if (playerCollision.HighJumpStarted)
        {
            transform.Translate(vector3 * highJump * Time.deltaTime);
        }
        else
        {
            transform.Translate(vector3 * height * Time.deltaTime);
        }
    }

    private void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer > jumpTime / 2 && timer <= jumpTime)
        {
            Moving(Vector3.up);
        }
        if (timer > 0 && timer <= jumpTime / 2)
        {
            Moving(Vector3.down);
        }
        if (timer < 0)
        {
            timer = 0;
            transform.position = new Vector3(0, 0.5f, 0);
            isJumping = false;
        }
    }
}
