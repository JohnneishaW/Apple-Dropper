using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour
{
    public Control c;
    public int hitGround=0;
    // Start is called before the first frame update
    void Start()
    {
        //hitGround = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //game over after 3 apples hit the ground
        if (hitGround == 3)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //apple disappears when it enters basket
        if (collision.gameObject.tag.Equals("Player")){
            Debug.Log("Collision! Apple hit basket.");
            this.gameObject.SetActive(false);
        }
        //apple disappear when it hits ground; a basket is removed
        if (collision.gameObject.tag.Equals("ground"))
        {
            Debug.Log("Apple hit ground!");
            hitGround += 1;
            Debug.Log("Wasted apples: " + hitGround);
            this.gameObject.SetActive(false);
            c.destroyBasket(true);
        }
    }
}
