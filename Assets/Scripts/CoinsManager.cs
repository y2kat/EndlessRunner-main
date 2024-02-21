using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenCoins;
    [SerializeField] private float speed = 5f;

    private float timer;
    private PoolScript coinsPool;
    private float[] lanes = new float[] { -3f, 0f, 3f };
    public Player player;

    void Start()
    {
        timer = timeBetweenCoins;
        coinsPool = GetComponent<PoolScript>();
    }

    void Update()
    {
        transform.position = transform.position - new Vector3(0, 0, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= timeBetweenCoins)
        {
            GameObject obj = coinsPool.RequestObject();

            float randX = lanes[Random.Range(0, lanes.Length)];
            obj.transform.position = new Vector3(randX, 1, 3);
            timer = 0;
        }

        List<GameObject> activeCoins = coinsPool.GetActiveObjects();
        for (int i = activeCoins.Count - 1; i >= 0; i--)
        {
            GameObject coin = activeCoins[i];
            if (coin.transform.position.z < player.transform.position.z)
            {
                StartCoroutine(coinsPool.DespawnObjectWithDelay(coin, 4f));
            }
        }
    }

    public void DespawnObject(GameObject objectToDespawn)
    {
        coinsPool.DespawnObject(objectToDespawn);
    }
}
