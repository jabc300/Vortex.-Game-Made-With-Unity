using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public static Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();
    private string keyReference;

    public static void CreateInstance(string objectTag, GameObject instantiatedObject, int quantity) {
        pool.Add(objectTag, new Queue<GameObject>());
        FillTheQueue(objectTag, instantiatedObject, quantity);
    }

    static void FillTheQueue(string objectTag, GameObject instantiatedObject, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            GameObject CreatedInstanceObject = Instantiate(instantiatedObject);
            pool[objectTag].Enqueue(CreatedInstanceObject);
            CreatedInstanceObject.SetActive(false);
        }
    }

    public static GameObject UsePoolObject(string ReferenceTag, Vector3 position, Quaternion rotation)
    {
        if (pool.ContainsKey(ReferenceTag))
        {
            if (pool[ReferenceTag].Count <= 1) {
                FillTheQueue(ReferenceTag, pool[ReferenceTag].Peek(),3);
            }
            GameObject newObjectToUse = pool[ReferenceTag].Dequeue();
            newObjectToUse.transform.position = position;
            newObjectToUse.transform.rotation = rotation;
            newObjectToUse.SetActive(true);
            if(ReferenceTag == "Miniboss")print("the object "+ newObjectToUse + " activation is "+ newObjectToUse.activeSelf);
            return (newObjectToUse as GameObject);
        }
        else { return null; }
        
    }

    public static void returnToQueque(GameObject GameObjectToReturn) {
        if (GameObjectToReturn)
        {
            GameObjectToReturn.transform.position = new Vector2(4000, 4000);
            GameObjectToReturn.transform.SetParent(null);
            GameObjectToReturn.transform.rotation = Quaternion.identity;
            pool[GameObjectToReturn.GetComponent<DictionaryKey>().TheKey].Enqueue(GameObjectToReturn);
            GameObjectToReturn.SetActive(false);
        }
        
    }
}
