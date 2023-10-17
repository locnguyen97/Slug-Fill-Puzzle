using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchPoint : MonoBehaviour
{
    private bool isSelected = false;
    public bool isHead = false;
    [SerializeField] List<GameObject> particleVFXs;
    private Vector3 startPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var p = other.transform.GetComponent<Point>();
        if (p != null)
        {
            GameManager.Instance.GetCurLevel().RemoveObject(p.gameObject);
            Destroy(p.gameObject);
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], p.transform.position, transform.rotation);
            Destroy(explosion, .75f);
        }
        var pl = other.transform.GetComponent<Panel>();
        if (pl != null)
        {
            GameManager.Instance.Pickup();
            transform.position = startPos;
        }
    }
}
