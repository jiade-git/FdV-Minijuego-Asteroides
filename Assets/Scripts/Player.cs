using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;


    public GameObject gun, bulletPrefab;

    public static double SCORE = 0;

    public static float xBorderLimit, yBorderLimit;
    private Rigidbody _rigid;














   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();



        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);


    }

    void Update()
    {

        if (!MenuPausa.gamePaused)
        {
            var newPos = transform.position;

            if (newPos.x > xBorderLimit)
                newPos.x = -xBorderLimit + 1;

            else if (newPos.x < -xBorderLimit)
                newPos.x = xBorderLimit - 1;

            else if (newPos.y > yBorderLimit)
                newPos.y = -yBorderLimit + 1;

            else if (newPos.y < -yBorderLimit)
                newPos.y = yBorderLimit - 1;

            transform.position = newPos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = PoolBalas.SharedInstance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = gun.transform.position;
                    bullet.transform.rotation = Quaternion.identity;
                    bullet.SetActive(true);
                }

                Bullet balaScript = bullet.GetComponent<Bullet>();

                balaScript.targetVector = transform.right;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (other.gameObject.CompareTag("Fragmento"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        else
        {

            Debug.Log("He colisionada con otra cosa...");
        }
    }


  


}
