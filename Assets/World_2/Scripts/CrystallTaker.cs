using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CrystallTaker : MonoBehaviour
{
    public List<GameObject> NeadableObjects = new();
    public List<GameObject> AddictedObjects = new();
    public bool set;
    // Start is called before the first frame update
    public void CheckObjects()
    {
        var result = from obj in NeadableObjects
                     where obj.activeSelf == true
                     select obj;
        if (result.Count() == NeadableObjects.Count())
        {
            foreach (var obj in AddictedObjects)
            {
                obj.SetActive(set);
            }
        }
    }
}
