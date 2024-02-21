using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenObstacles;
    [SerializeField] private float speed = 5f;

    private float timer;
    private PoolScript obstaclePool;
    private float[] lanes = new float[] { -3f, 0f, 3f };
    public Player player;

    void Start()
    {
        timer = timeBetweenObstacles;
        obstaclePool = GetComponent<PoolScript>();
    }

    void Update()
    {
        transform.position = transform.position - new Vector3(0, 0, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= timeBetweenObstacles)
        {
            GameObject obj = obstaclePool.RequestObject();

            float randX = lanes[Random.Range(0, lanes.Length)];
            obj.transform.position = new Vector3(randX, 1, 3);
            timer = 0;
        }

        List<GameObject> activeObstacles = obstaclePool.GetActiveObjects();
        for (int i = activeObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = activeObstacles[i];
            if (obstacle.transform.position.z < player.transform.position.z)
            {
                StartCoroutine(obstaclePool.DespawnObjectWithDelay(obstacle, 4f));
            }
        }
    }

    public void DespawnObject(GameObject objectToDespawn)
    {
        obstaclePool.DespawnObject(objectToDespawn);
    }
}
