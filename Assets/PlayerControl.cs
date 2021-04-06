using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Tombol untuk menggerakkan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakkan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scene (Batas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor pemain
    private int score;
    public int Score
    {
        get { return score; }
    }

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        // P L A Y E R  M O V E M E N T
        //

        // Dapatkan kecepatan raket
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemain menekan tombol UP, maka assign value
        // positif ke sumbu y (bergerak ke atas)
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol DOWN, maka assign value
        // negatif ke sumbu y (bergerak ke bawah)
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apapun,
        // maka kecepatannya nol
        else
        {
            velocity.y = 0.0f;
        }

        // Masukkan kecepatan ke RigidBody2D
        rigidBody2D.velocity = velocity;

        //
        // P L A Y E R  B O U N D A R Y
        // 

        // Dapatkan posisi raket
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas (yBoundary),
        // maka kembalikan ke batas atas tersebut
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary),
        // maka kembalikan ke batas bawah tersebut
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    // Menaikkan skor sebanyak satu poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikkan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }
}
