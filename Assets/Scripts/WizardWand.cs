using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWand : MonoBehaviour
{
    public GameObject collectibleItemPrefab;
    public GameObject unCollectibleItemPrefab;

    public float throwingPower = 10f;
    public float throwingDistance = 2f;
    public float throwingAngle = 45f;
    public float throwUpAngleLimit = 45f;
    public float throwDownAngleLimit = -45f;
    public float itemProductionTime = 2f;
    public float itemProductionAmount = 1f;
    public float randomBombItem = 5f;
    public float randomItemSpeedMin = 500f;
    public float randomItemSpeedMax = 1000f;

    private float nextItemTime = 0f;

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
        Vector3 throwingPosition = new Vector3(transform.position.x - throwingDistance, transform.position.y, transform.position.z);
        float randomItem = Random.Range(0f, 100f);
        GameObject item;
        for (int i = 0; i< itemProductionAmount; i++)
        {
            if (randomItem < randomBombItem)
            {
                item = Instantiate(unCollectibleItemPrefab, throwingPosition, Quaternion.identity);
            }
            else
            {
                item = Instantiate(collectibleItemPrefab, throwingPosition, Quaternion.identity);
            }
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();

            // firlatma yönü hesapla
            float throwingAngle1 = Random.Range(-throwingAngle, throwingAngle);
            float throwingDirectionX = -Mathf.Cos(throwingAngle1 * Mathf.Deg2Rad);
            float throwingDirectionY = Mathf.Sin(throwingAngle1 * Mathf.Deg2Rad);
            float throwingDirectionUp = Random.Range(throwDownAngleLimit, throwUpAngleLimit);
            Vector2 throwingDirection = new Vector2(throwingDirectionX, throwingDirectionY);
            throwingDirection = Quaternion.Euler(0f, 0f, throwingDirectionUp) * throwingDirection;
            throwingPower = Random.Range(randomItemSpeedMin, randomItemSpeedMax);

            rb.AddForce(throwingDirection * throwingPower);
        }
       
        
    }
}
