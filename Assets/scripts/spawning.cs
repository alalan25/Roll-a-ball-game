using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject object1;
    private GameObject object1_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(3, 0, 0);

        for (int i = 0; i < 5; i++)
        {
            object1 = Instantiate(object1_Prefab);
            object1.transform.position = object1.transform.position + i * offset;
        }
    }

    
   
}
