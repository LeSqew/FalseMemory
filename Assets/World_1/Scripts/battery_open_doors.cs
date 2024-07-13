using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery_open_doors : MonoBehaviour
{
    public List<Battery_Place> places = new List<Battery_Place>();

    public GameObject door;

    // Update is called once per frame
    void Update()
    {
        int con = 0;
        for (int i = 0; i < places.Count; i++)
        {
            if (places[i].busy)
            {
                con++;
            }
        }

        if (con == places.Count)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}

[System.Serializable]
public class Battery_Place
{
    public GameObject place;
    public bool busy;
}
