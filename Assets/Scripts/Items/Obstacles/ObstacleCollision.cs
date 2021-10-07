using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [Header("Player")]
    private GameObject player;
    private string nameTag = "Player";

    [Header("Local")]
    private float size;

    public float Scale { get; set; }

    private void Start()
    {
        size = Scale / 2 + 0.5f;
        player = GameObject.FindWithTag(nameTag);
    }

    private void FixedUpdate() => Collision();

    private void Collision()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= size)
        {
            Time.timeScale = 0;
        }
    }
}
