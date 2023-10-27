using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Спавнер движущегося объекта
/// </summary>
public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject shrimp, bomb;
    private List<GameObject> shrimps;
    private List<GameObject> bombs; 

    void Remove()
    {
        if (shrimps != null)
            foreach (var go in shrimps)  Destroy(go);
        if (bombs != null)
            foreach (var go in bombs)  Destroy(go);
    }
    
    public void StartGame()
    {
        Remove();
        shrimps = new List<GameObject>();
        bombs = new List<GameObject>();
        for (int i=0; i<4; i++)
        {
          var _shrimp = Instantiate(shrimp, new Vector2(-4.5f, -2.74f), Quaternion.identity);
            shrimps.Add(_shrimp);
            _shrimp.SetActive(false);
          var _bomb = Instantiate(bomb, new Vector2(-4.5f, -2.74f), Quaternion.identity);
            bombs.Add(_bomb);
            _bomb.SetActive(false);
        }
        StartCoroutine(RandomLaunch());
    }

    IEnumerator RandomLaunch()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 3));
            var rand = Random.Range(0, 100);
            if (rand < 80)
            {
                ObjectSelector(shrimps)?.StartMove();
            }
            else
            {
                ObjectSelector(bombs)?.StartMove();
            }
        }
    }

    ObjectController ObjectSelector(List<GameObject> obj)
    {
        foreach(var element in obj)
        {
            if (element != null)
            {
                if(element.TryGetComponent<ObjectController>(out var controller))
                {
                    if (!controller.isMoving) return controller;
                }
            }
        }
        return null;  
    }
     
    public void GameOver()
    {
        StopCoroutine(RandomLaunch());
        Remove();
    }
}
