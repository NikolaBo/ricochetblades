using UnityEngine;
using System.Collections;

public class ThrowingBladeProjectile : MonoBehaviour {

    private GameObject gb;
    public string team;
    public string enemy;
    public float damage = 10;
    public AudioSource bounce;
    public AudioSource kill;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == team) {
            col.gameObject.BroadcastMessage("ResetSword");
            //Debug.Log("hit player");
            Destroy(gameObject);
        }
        if (col.gameObject.tag == enemy)
        {
            col.gameObject.SendMessage("ApplyDamage", damage);
            kill.Play();
        }
        else if(col.gameObject.tag == "level") {
            bounce.Play();
        }
    }
}
