using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CrystallManager : MonoBehaviour
{
    public Dictionary<CrystallColors, bool> crystalls = new Dictionary<CrystallColors, bool>();
    public List<GameObject> images = new List<GameObject>();

    public GameObject eImage;
    private bool onCrystallTaker = false;
    private CrystallTaker crystallTaker;

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(CrystallColors)).Length; i++)
        {
            crystalls.Add((CrystallColors)i, false);
        }
    }
    void Update()
    {
        if (onCrystallTaker && crystallTaker != null && Input.GetKeyDown(KeyCode.E))
        {
            crystallTaker.CheckObjects();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Crystall")
        {
            var crystallColor = collision.GetComponentInParent<Crystall>().color;
            crystalls[crystallColor] = true;
            foreach(var image  in images)
            {
                if (image.GetComponent<Crystall>().color == crystallColor)
                {
                    image.SetActive(true);
                }
            }
            
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Crystall Taker")
        {
            eImage.SetActive(true);
            onCrystallTaker = true;
            crystallTaker = collision.gameObject.GetComponent<CrystallTaker>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Crystall Taker")
        {
            eImage.SetActive(false);
            onCrystallTaker = false;
            crystallTaker = null;
        }
    }
}
