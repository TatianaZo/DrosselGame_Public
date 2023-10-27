using System;
using System.Collections;
using UnityEngine;
/// <summary>
/// Менеджер лапки кота
/// </summary>
public class CatController: MonoBehaviour
{
    public Action onEdible, onBomb;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var go = collider.gameObject.GetComponent<ObjectController>();

        if (collider.gameObject.tag == "Edible" && go.isMoving)
        {
            onEdible?.Invoke();
        }
        
        if (collider.gameObject.tag == "Bomb" && go.isMoving)
        {
            onBomb?.Invoke();
        }
        go.StopMove();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(RotationLapka());
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)|| (Input.GetMouseButtonDown(0)))
        {
            StartCoroutine( RotationLapka());
        }
    }

    public IEnumerator RotationLapka()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -22);
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
