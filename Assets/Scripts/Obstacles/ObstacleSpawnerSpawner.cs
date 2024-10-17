using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpanwerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ObstacleSpwaner;
    // int posY;
    [SerializeField]
    private float spawnInterval = 1.5f;
    private float obstacleSpeed = 10f;
    private float spawnerXOffset = 5f;  // 스포너의 x 좌표 오프셋 (왼쪽은 -5, 오른쪽은 +5)
    private  Vector3 spawnPos;
    // Start is called before the first frame update

    void Start()
    {
       StartSpawnerRoutine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartSpawnerRoutine() {
        // 병렬처리 해주는 함수
        StartCoroutine("SpawnerRoutine"); 
    }
    

    IEnumerator SpawnerRoutine() {
        yield return new WaitForSeconds(1f);
        while (true) {
            SpawnSpawner();

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnSpawner() {

        if (Random.Range(0, 2) == 0)
        {
            // 왼쪽 스포너 위치 (x = -5, 최상단 객체의 y, z 사용)
            spawnPos = new Vector3( spawnerXOffset , transform.position.y, transform.position.z );
        }
        else
        {
            // 오른쪽 스포너 위치 (x = +5, 최상단 객체의 y, z 사용)
            spawnPos = new Vector3( -spawnerXOffset , transform.position.y, transform.position.z );
        }
        Vector3 direction = (spawnPos.x < 0) ? Vector3.right : Vector3.left;
        GameObject spawner = Instantiate( ObstacleSpwaner, spawnPos , Quaternion.identity);
        obstacleSpeed = Random.Range(0, 10f);
        spawner.GetComponent<ObstacleSpawner>().Initialize(direction, obstacleSpeed);
        // Vector3 spawnPos = new Vector3( transform.position.x , transform.position.y, transform.position.z );
        // Instantiate( ObstacleSpwaner, spawnPos, Quaternion.identity );
    }
}
