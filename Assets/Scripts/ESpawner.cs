using UnityEngine;

public class ESpawner : MonoBehaviour
{

    public float timeBetweenSpawns;
    private float timer;

    public GameObject enemy;
    private float time;

    public ObjectPool pool;

    // Bounds for spawn area
    public Vector2 spawnAreaMin = new Vector2(-5f, -5f); // bottom-left of spawn area
    public Vector2 spawnAreaMax = new Vector2(5f, 5f);   // top-right of spawn area

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timeBetweenSpawns;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            // Generate a random position within the spawn area
            float randX = UnityEngine.Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector3 spawnPos = new Vector3(randX, randY, 0f);

            GameObject go = pool.getPooledObject();

            if (go != null)
            {
                go.transform.position = spawnPos;
                go.SetActive(true);

            }

            timer = timeBetweenSpawns;
        }
    }
}
