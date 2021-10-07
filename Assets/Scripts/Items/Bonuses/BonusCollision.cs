using UnityEngine;

public class BonusCollision : MonoBehaviour
{
    [Header("Player")]
    private GameObject player;
    private string nameTag = "Player";

    [Header("Size")]
    [SerializeField] private float size = 1f;

    [Header("Type")]
    [SerializeField] private int type = 1;

    private void Start() => player = GameObject.FindWithTag(nameTag);

    private void FixedUpdate() => Collision();

    private void Collision()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= size)
        {
            if (type == 1)
            {
                player.GetComponent<PlayerCollision>().AccelerationStarted = true;
            }
            if (type == 2)
            {
                player.GetComponent<PlayerCollision>().HighJumpStarted = true;
            }
            Destroy(gameObject);
        }
    }
}
