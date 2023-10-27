using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Менеджер движущегося объекта
/// </summary>
public class ObjectController : MonoBehaviour
{
    public bool isMoving = false;
    [SerializeField] GameObject star;
    public Vector2 origin = new Vector2(-4.5f, -2.74f);
    public void StartMove()
    {
        isMoving = true;
        gameObject.SetActive(true);
        StartCoroutine(MoveObject());
    }

    public void StopMove()
    {
        isMoving = false;
        StopCoroutine(MoveObject());
        StartCoroutine(StarsOn());
    }

    public void ReturnToGarage()
    {
        transform.position = origin;
    }

    IEnumerator StarsOn()
    {
        star?.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        star?.SetActive(false);
        gameObject?.SetActive(false);
        ReturnToGarage();
    }

    IEnumerator MoveObject()
    {
        var transfRand = Random.Range(0.1f, 0.5f);
        float waitRand = Random.Range(0.1f, 0.5f);
        while (isMoving)
        {
            gameObject.transform.position += new Vector3(transfRand, 0, 0);
            yield return new WaitForSeconds(waitRand);
        }
    }
}