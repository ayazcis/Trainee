using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWand : MonoBehaviour
{
    [SerializeField] List<GameObject> collectibleItemPrefab;
    [SerializeField] List<GameObject> unCollectibleItemPrefab;

    [SerializeField] float throwingPower = 800f;
    [SerializeField] float throwingDistanceX = 0f;
    [SerializeField] float throwingDistanceY = 0f;
    [SerializeField] float throwingAngle = 10f;
    [SerializeField] float throwUpAngleLimit = 17f;
    [SerializeField] float throwDownAngleLimit = -17f;
    [SerializeField] float itemProductionTime = 1f;
    [SerializeField] float itemProductionAmount = 1f;
    [SerializeField] float randomBombItem = 5f;
    [SerializeField] float randomItemSpeedMin = 500f;
    [SerializeField] float randomItemSpeedMax = 1000f;
    private Rigidbody2D rb;
    private float nextItemTime = 0f;
    private Vector2 throwingDirection;
    Renderer itemRenderer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextItemTime)
        {
            ThrowItem();
            nextItemTime = Time.time + itemProductionTime;
        }
    }

    private void ThrowItem()
    {
        Vector3 throwingPosition = new Vector3(transform.position.x - throwingDistanceX, transform.position.y - throwingDistanceY, transform.position.z);
        float randomItem = Random.Range(0f, 100f);
        GameObject item;
        for (int i = 0; i < itemProductionAmount; i++)
        {
            if (randomItem < randomBombItem)
            {
                item = Instantiate(unCollectibleItemPrefab[Random.Range(0, unCollectibleItemPrefab.Count)], throwingPosition, Quaternion.identity);
                itemRenderer = item.GetComponent<Renderer>();
                itemRenderer.material.color = new Color32(243, 151, 151, 255);
            }
            else
            {
                item = Instantiate(collectibleItemPrefab[Random.Range(0, collectibleItemPrefab.Count)], throwingPosition, Quaternion.identity);
            }
           
            
            rb = item.GetComponent<Rigidbody2D>();

            // firlatma yönü hesapla
            float throwingAngle1 = Random.Range(-throwingAngle, throwingAngle);
            float throwingDirectionX = -Mathf.Cos(throwingAngle1 * Mathf.Deg2Rad);
            float throwingDirectionY = Mathf.Sin(throwingAngle1 * Mathf.Deg2Rad);
            float throwingDirectionUp = Random.Range(throwDownAngleLimit, throwUpAngleLimit);
            throwingDirection.x = throwingDirectionX;
            throwingDirection.y = throwingDirectionY;
            throwingDirection = Quaternion.Euler(0f, 0f, throwingDirectionUp) * throwingDirection;
            throwingPower = Random.Range(randomItemSpeedMin, randomItemSpeedMax);

            rb.AddForce(throwingDirection * throwingPower);
        }
       
        
    }
}
