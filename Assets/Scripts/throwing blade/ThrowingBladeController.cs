using UnityEngine;
using System.Collections;

public class ThrowingBladeController : MonoBehaviour {

    public KeyCode attack;
    public PlatformerMotor2D parentMotor;
    public bool facingLeft;
    public bool holdingSword = true;
    public Transform leftSpawn;
    public Transform rightSpawn;
    public GameObject swordPrefab;
    public float speed;
    private GameObject rb;
    public GameObject visual;
    public bool canThrowLeft = true;
    public bool canThrowRight = true;
    public AudioSource catchSFX;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (parentMotor.velocity.x <= -0.1f)
        {
            facingLeft = true;
        }
        else if (parentMotor.velocity.x >= 0.1f)
        {
            facingLeft = false;
        }

        Vector3 rotateDir = facingLeft ? Vector3.forward : Vector3.back;
        if (Input.GetKeyDown(attack) && holdingSword) {
            if (facingLeft && canThrowLeft)
            {
                rb = Instantiate(swordPrefab, leftSpawn.position, Quaternion.identity) as GameObject;
                Rigidbody2D rigid = rb.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.left * speed);
                holdingSword = false;
                visual.SetActive(false);
            }
            else if (facingLeft && canThrowRight){
                rb = Instantiate(swordPrefab, rightSpawn.position, Quaternion.identity) as GameObject;
                Rigidbody2D rigid = rb.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * speed);
                holdingSword = false;
                visual.SetActive(false);    
            }
            if (!facingLeft && canThrowRight) {
                rb = Instantiate(swordPrefab, rightSpawn.position, Quaternion.identity) as GameObject;
                Rigidbody2D rigid = rb.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * speed);
                holdingSword = false;
                visual.SetActive(false);   
            }
            else if (!facingLeft && canThrowLeft) {
                rb = Instantiate(swordPrefab, leftSpawn.position, Quaternion.identity) as GameObject;
                Rigidbody2D rigid = rb.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.left * speed);
                holdingSword = false;
                visual.SetActive(false);
            }
        }
	}
    void ResetSword() {
        holdingSword = true;
        visual.SetActive(true);
        catchSFX.Play();
    }
}
