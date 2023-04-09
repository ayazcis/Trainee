using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CollectibleItems : MonoBehaviour
{

    private ScoreBar scoreBar;
    private float leftScreenEdge;
    private float rightScreenEdge;
    private float topScreenEdge;
    private float bottomScreenEdge;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        topScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        scoreBar = FindObjectOfType<ScoreBar>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyItemWhenOffScreem();

    }
    private void OnMouseDown()
    {
        //
        DestroyItem(gameObject);

    }

    private void DestroyItem(GameObject gameObject)
    {
        Debug.Log("Clicked");
        float animLength;
        switch (gameObject.tag)
        {
            case "Collectible":
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                animator.SetBool("isDestroyed", true);
                animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine(DestroyAfterAnimation(gameObject, animLength));
                if (scoreBar.gameScore != 100f)
                {
                    scoreBar.increaseScore();
                }
                break;
            case "UnCollectible":
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                animator.SetBool("isDestroyed", true);
                animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                StartCoroutine(DestroyAfterAnimation(gameObject, animLength));
                if (scoreBar.gameScore != 0f)
                {
                    scoreBar.decreaseScore();
                }
                break;
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

    IEnumerator DestroyAfterAnimation(GameObject gameObject, float animLength)
    {
        yield return new WaitForSeconds(animLength);
        Destroy(gameObject);
    }
}
