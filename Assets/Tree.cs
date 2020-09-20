using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool isRight;
    public float speed;
    public Transform border;
    public GameObject apple;
    public GameObject tree;
    private float spawnTime;
    private float nextSpawnTime =2.0f;
    /*
    public Rigidbody2D rb;
    
    public float accelerationTime = 25f;
    private Vector2 movement;
    float yposition;
    public float maxSpeed = 5f;
    */

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time + 2.0f; ;
        /*
        rb = GetComponent<Rigidbody2D>();
        yposition = transform.position.y;
        */
    }

    private void Update()
    {
        //check if tree is colliding with side of screen
        RaycastHit2D hit = Physics2D.Raycast(border.position, Vector2.down, 1f);
        if (hit.collider == null)
        {
            speed *= -1;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            spawnTime = Time.time + 5.0f;
        }
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);

        //respawn apple every couple of seconds
        if (Time.time > spawnTime)
        {
            Vector3 treePosition = new Vector3(tree.transform.position.x, tree.transform.position.y, tree.transform.position.z);
            Instantiate(apple, treePosition, Quaternion.identity);
            //decrease spawn time; spawn apples faster
            nextSpawnTime -= 0.01f;
            spawnTime += nextSpawnTime;
        }
    }
    // Update is called once per frame

    /*
    void Update()
    {
        time -= Time.deltaTime;
        //get a new random direction every couple of seconds
        if (time <= 0)
        {
            movement = new Vector2(Random.Range(1f, 2f), yposition);
            time += accelerationTime;
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
    */


}
