using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public float health = 10;
    public GameObject deathEffect;
    public Transform[] respawnPoints;
    public Transform effectSpawn;
    public bool red;
    public GameManager manager;
    private Vector3 originalSpawn;
    public bool shielded = false;

	// Use this for initialization
	void Start () {
        originalSpawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyDamage(float damage) {
        if (shielded)
        {
            shielded = false;
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                Death();
            }
        }
    }
    void Death() {
        Instantiate(deathEffect, effectSpawn.position, Quaternion.identity);
        manager.AddPoint(!red);
        transform.position = respawnPoints[Mathf.RoundToInt(Random.Range(0,respawnPoints.Length))].position;
    }
    void Reset() {
        transform.position = originalSpawn;
    }
    void OnCollisionEnter2D(Collision2D hit) {
        Debug.Log("triggered");
        //if (!shielded)
        //{
            if (hit.gameObject.tag == "shield" && hit.gameObject.activeInHierarchy)
            {
                Debug.Log("shielded");
                shielded = true;
                hit.gameObject.SetActive(false);
            }
        //}
    }
}
