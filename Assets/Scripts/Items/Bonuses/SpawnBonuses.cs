using System.Collections;
using UnityEngine;

public class SpawnBonuses : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject acceleration;
    [SerializeField] private GameObject highJump;

    [Header("Spawn time")]
    [SerializeField] private float startTime = 10f;
    [SerializeField] private float time = 32f;

    [Header("Start")]
    [SerializeField] private float start = 15f;

    [Header("Local")]
    private GameObject[] array;

    private void Start()
    {
        array = new GameObject[2] { acceleration, highJump };
        StartCoroutine(Spawn_bonuses());
    }

    IEnumerator Spawn_bonuses()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            Instantiate(array[Random.Range(0, array.Length)], new Vector3(start, 1, 0), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
