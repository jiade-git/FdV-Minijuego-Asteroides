using UnityEngine;

public class FragmentoAsteroide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public Vector3 targetVector; // se lo pasa la bala al crearlo

    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false); // destruir bala
            Destroy(gameObject); // destruir fragmento



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
