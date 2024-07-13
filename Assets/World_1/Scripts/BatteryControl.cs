using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatteryControl : MonoBehaviour
{

    private bool OnBattery = false;
    private bool OnPlaceBat = false;
    private bool OnHand = false;
    private bool OnMindBreak;
    public GameObject eImage;
    private GameObject bat;
    private GameObject PlaceBat;
    private GameObject Check_Door;

    public GameObject canvas;
    public GameObject Item_Place; // куда крепится батарейка

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (OnHand)
        {
            bat.transform.position = Item_Place.transform.position;
        }

        if(OnPlaceBat && OnHand && Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < Check_Door.GetComponent<battery_open_doors>().places.Count; i++)
            {
                if (PlaceBat == Check_Door.GetComponent<battery_open_doors>().places[i].place && Check_Door.GetComponent<battery_open_doors>().places[i].busy == false)
                {
                    OnHand = false;
                    bat.transform.position = PlaceBat.transform.position;
                    bat.GetComponent<CircleCollider2D>().enabled = true;

                    for (int j = 0; j < Check_Door.GetComponent<battery_open_doors>().places.Count; j++)
                    {
                        if (PlaceBat == Check_Door.GetComponent<battery_open_doors>().places[j].place)
                        {
                            Check_Door.GetComponent<battery_open_doors>().places[j].busy = true;
                            break;
                        }
                    }
                    break;
                }
            }

            
            //Debug.Log(123);
        }

        if (OnBattery && Input.GetKeyDown(KeyCode.E) && !OnHand)
        {
            
            bat.transform.position = Item_Place.transform.position;
            bat.GetComponent<CircleCollider2D>().enabled = false;
            OnHand = true;
            OnBattery = false;

            for (int i = 0; i < Check_Door.GetComponent<battery_open_doors>().places.Count; i++)
            {
                if (PlaceBat == Check_Door.GetComponent<battery_open_doors>().places[i].place)
                {
                    Check_Door.GetComponent<battery_open_doors>().places[i].busy = false;
                    break;
                }
            }

        }
        if (OnMindBreak && Input.GetKeyDown(KeyCode.E) && !canvas.activeSelf) {
            canvas.SetActive(true);
        }
        else if (OnMindBreak && Input.GetKeyDown(KeyCode.Escape) && canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
        else if (!OnMindBreak)
        {
            canvas.SetActive(false);
        }

    }


    /// <summary>
    /// Разворачивает персонажа вправо и влево, взависимости от того куда идет игрок
    /// </summary>


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "batteyr" && !OnHand)
        {
            OnBattery = true;
            bat = collision.gameObject;
        }

        if(collision.tag == "battery_Place")
        {
            eImage.SetActive(true);
            OnPlaceBat = true;
            PlaceBat = collision.gameObject;
        }

        if(collision.tag == "Check_Door")
        {
            Check_Door = collision.gameObject;
        }
        if (collision.tag == "Mind Break")
        {
            eImage.SetActive(true);
            OnMindBreak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "batteyr")
        {
            OnBattery = false;
            //bat = null;
        }

        if (collision.tag == "battery_Place")
        {
            eImage.SetActive(false);
            OnPlaceBat = false;
            PlaceBat = null;
        }

        if (collision.tag == "Check_Door")
        {
            Check_Door = null;
        }
        if (collision.tag == "Mind Break")
        {
            eImage.SetActive(false);
            OnMindBreak = false;
        }
    }
}
