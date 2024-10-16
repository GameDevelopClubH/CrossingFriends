using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    [SerializeField]
    private float moveSpeed = 10f;
    private float maxX = 5f;
    private float minY = -5f;
    private Vector3 direction;
    // Start is called before the first frame update
    public void Initialize(Vector3 direction, float moveSpeed) {
        this.direction = direction;
        this.moveSpeed = moveSpeed;
    }
    void Start()
    {
        moveSpeed = Random.Range(0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
        if (transform.position.x > maxX || transform.position.y < minY) {
            Destroy(gameObject); 
        }
    }
}
