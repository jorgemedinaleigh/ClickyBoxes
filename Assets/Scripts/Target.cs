using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 5;
    private float ySpawnPos = -3;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); 

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPos();   

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() 
    {  
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        if(gameObject.name == "Barril(Clone)")
        {
            gameManager.UpdateScore(10);
            gameManager.mouseClicks = 0;
        }
        else if(gameObject.name == "Caja(Clone)")
        {
            gameManager.UpdateScore(1);
            gameManager.mouseClicks = 0;
        }
        else if(gameObject.name == "CajaRandom(Clone)")
        {
            int randomScore = Random.Range(-5, 15);
            gameManager.UpdateScore(randomScore);
            gameManager.mouseClicks = 0;
        }
        else if(gameObject.name == "Bomba(Clone)")
        {
            gameManager.UpdateScore(-10);
            gameManager.mouseClicks = 0;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}
