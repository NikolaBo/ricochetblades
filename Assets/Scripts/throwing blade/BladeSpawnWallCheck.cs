using UnityEngine;
using System.Collections;

public class BladeSpawnWallCheck : MonoBehaviour {

    public ThrowingBladeController controller;
    public bool left;
    public string layerName;
    //public GameObject level;

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log(col.gameObject.ToString());
        if (col.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
            if (left)
            {
                controller.canThrowLeft = false;
                Debug.Log("can't left");
            }
            else
            {
                controller.canThrowRight = false;
                Debug.Log("can't right");
            }
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
            if (left)
            {
                controller.canThrowLeft = true;
                Debug.Log("can left");
            }
            else
            {
                controller.canThrowRight = true;
                Debug.Log("can right");
            }
        }
    }
}
