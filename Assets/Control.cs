using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    float yposition;
    private int score;
    public TMPro.TextMeshProUGUI ScoreText;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Setting baskets and score");
        this.gameObject.SetActive(true);
        score = 0;
        yposition = transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
    }
  
    private void OnMouseDrag()
    {
        Debug.Log("Basket dragged.");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x, yposition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Apple")){
            score += 1;
            Debug.Log("Apple collected." + score);
        }
        
    }
    
    public void destroyBasket(bool destroy)
    {
        if (destroy)
        {
            Debug.Log("Destroying basket!");
            //Destroy(this);
            this.gameObject.SetActive(false);
        }

    }

}
