using System.Collections;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject obstacleAcceleration;

    [Header("PlayerCollision")]
    [SerializeField] private PlayerCollision playerCollision;

    [Header("Spawn scale")]
    [SerializeField] private float scale_min = 1f;
    [SerializeField] private float scale_max = 2f;

    [Header("Spawn time")]
    [SerializeField] private float time_min = 3f;
    [SerializeField] private float time_max = 5f;

    [Header("Start")]
    [SerializeField] private float start = 15f;

    [Header("Local")]
    private GameObject _obstacle;
    private float scale;

    private void Start() => StartCoroutine(Spawn_obstacles());

    IEnumerator Spawn_obstacles()
    {
        while (true)
        {
            if (playerCollision.AccelerationStarted)
            {
                Obstacle(obstacleAcceleration);
            }
            else
            {
                Obstacle(obstacle);
                _obstacle.GetComponent<ObstacleCollision>().Scale = scale;
            }
            yield return new WaitForSeconds(Random.Range(time_min, time_max));
        }
    }

    private void Obstacle(GameObject obstacle)
    {
        scale = Random.Range(scale_min, scale_max);
        _obstacle = Instantiate(obstacle, new Vector3(start, scale / 2, 0), Quaternion.identity);
        _obstacle.transform.localScale = new Vector3(scale, scale, scale);
    }
}
