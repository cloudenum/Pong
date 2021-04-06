using UnityEngine;

public class BallControl : MonoBehaviour
{
    // RigidBody2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    // public float speed;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0, 0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0, 0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // float yRandomInitialForce = Random.Range(-xInitialForce, xInitialForce);
        // float xRandomInitialForce = Mathf.Sqrt((Mathf.Pow(speed, 2) - yRandomInitialForce / 5)) * 5;
        // Debug.Log("xRandomInitialForce: " + xRandomInitialForce);
        // Debug.Log("yRandomInitialForce: " + yRandomInitialForce);
        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)        
        float yRandomDirectionInitialForce = yInitialForce;
        if (Random.Range(0, 2) < 1.0f)
        {
            yRandomDirectionInitialForce = -yInitialForce;
        }

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (Random.Range(0, 2) < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomDirectionInitialForce));
            // rigidBody2D.AddForce(transform.position * (-speed));
            // rigidBody2D.velocity = new Vector2(-xInitialForce, yRandomDirectionInitialForce);
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomDirectionInitialForce));
            // rigidBody2D.AddForce(transform.position * speed);
        }
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();
        Debug.Log("Reset Ball");
        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;

        // Mulai game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
