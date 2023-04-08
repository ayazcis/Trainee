using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleItems : MonoBehaviour
{

    private ScoreBar scoreBar;
    private float leftScreenEdge;
    private float rightScreenEdge;
    private float topScreenEdge;
    private float bottomScreenEdge;

    // Start is called before the first frame update
    void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        topScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        scoreBar = FindObjectOfType<ScoreBar>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyItemWhenOffScreem();

    }
    private void OnMouseDown()
    {
        //Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
        DestroyItem(gameObject);

    }

    private void DestroyItem(GameObject gameObject)
    {
        Debug.Log("Clicked");
        if (gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collectible");
            Destroy(gameObject);
            scoreBar.increaseScore();
        }
        else if (gameObject.CompareTag("UnCollectible"))
        {
            Debug.Log("UnCollectible");
            Destroy(gameObject);
            scoreBar.decreaseScore();

        }

    }

    private void DestroyItemWhenOffScreem()
    {
    
        if (transform.position.x < leftScreenEdge || transform.position.x > rightScreenEdge 
            ||transform.position.y < bottomScreenEdge || transform.position.y > topScreenEdge)
        {
            Destroy(gameObject);
            if (scoreBar.gameScore != 0f)
            {
                scoreBar.decreaseScore();
            }
        }
    }
}
