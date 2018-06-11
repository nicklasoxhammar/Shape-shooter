using UnityEngine;

public class EnemyShape : MonoBehaviour {

    public Vector2 startForce;

    public Rigidbody2D rb;

    public GameObject nextBall;

    Vector2 leftWall = new Vector2(5f, 0f);
    Vector2 rightWall = new Vector2(-5f, 0f);
    Vector2 bottomWall = new Vector2(0f, 5f);

    public float maxVelocity = 10f;

    void Start () {
        rb.AddForce(startForce);
	}

    void Update() {
        if (rb.velocity.magnitude > maxVelocity) {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
	
	public void Split() {

        if (nextBall != null) {
            GameObject shape1 = Instantiate(nextBall, rb.position + Vector2.right / 6f, Quaternion.identity) as GameObject;
            GameObject shape2 = Instantiate(nextBall, rb.position + Vector2.left / 6f, Quaternion.identity) as GameObject;

            shape1.GetComponent<EnemyShape>().startForce = new Vector2 (10f, 30f);
            shape2.GetComponent<EnemyShape>().startForce = new Vector2 (-10f, 30f);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "WallLeft") {
            rb.AddForce(leftWall);

        }else if(col.gameObject.name == "WallRight") {
            rb.AddForce(rightWall);

        }else if(col.gameObject.name == "WallBottom") {
            rb.AddForce(bottomWall);
        }

    }
}
