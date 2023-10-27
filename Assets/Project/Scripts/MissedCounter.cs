using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedCounter : MonoBehaviour
{
    public Action onMissed;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Edible")
        {
            onMissed?.Invoke();
            collider.gameObject.GetComponent<ObjectController>().StopMove();
        }
    }
}
