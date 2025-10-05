using UnityEngine;

public class Asteroide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   


     public float maxLifeTime = 5f;


    private float lifeTimer;

    private Rigidbody rb;

      void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        lifeTimer = maxLifeTime; // reiniciar el temporizador cada vez que se activa

         if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
       

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false); // volver al pool
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false); // destruir bala
            gameObject.SetActive(false); // destruir fragmento



            IncreaseScoreFragmento();
            

        }
    }


    private void IncreaseScoreFragmento()
    {
        Player.SCORE += 0.5; ;
        Debug.Log(Player.SCORE);
        Bullet.UpdateScoreText();
    }
    
    
}
