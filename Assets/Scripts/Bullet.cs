using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;

    public float maxLifeTime = 3f;



    public GameObject fragmentoAsteroide;

    public UnityEngine.Vector3 targetVector;



    private float lifeTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        lifeTimer = maxLifeTime; // reiniciar el temporizador cada vez que se activa
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false); // volver al pool
        }
    }

    private void OnTriggerEnter(Collider other)
  
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();





            other.gameObject.SetActive(false);
            gameObject.SetActive(false);


            UnityEngine.Vector3 dir1 = UnityEngine.Quaternion.Euler(0, 0, 45) * targetVector;
            UnityEngine.Vector3 dir2 = UnityEngine.Quaternion.Euler(0, 0, -45) * targetVector;


            GameObject frag1 = Instantiate(fragmentoAsteroide, other.transform.position, UnityEngine.Quaternion.identity);
            GameObject frag2 = Instantiate(fragmentoAsteroide, other.transform.position, UnityEngine.Quaternion.identity);


            FragmentoAsteroide f1 = frag1.GetComponent<FragmentoAsteroide>();
            FragmentoAsteroide f2 = frag2.GetComponent<FragmentoAsteroide>();

             if (f1 != null) f1.targetVector = dir1.normalized;
             if (f2 != null) f2.targetVector = dir2.normalized;


            
        }

         

         
        /*
        else
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        */
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    
    public static void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
}
