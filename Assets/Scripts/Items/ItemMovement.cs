using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [Header("Death Time")]
    [SerializeField] private float time = 6.5f;
    
    [Header("Speed")]
    [SerializeField] private float speed = 3f;

    private void Start() => Destroy(gameObject, time);

    private void FixedUpdate() => transform.Translate(-Vector3.right * speed * Time.deltaTime);
}
