using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rootLeft : MonoBehaviour
{
 
    public GameObject[] roots;
    public Transform leftEnd;
    public GameObject rightSide;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Transform parent = GetComponentInParent<Transform>();
        GameObject root = Instantiate(roots[0], new Vector3(leftEnd.position.x, leftEnd.position.y, leftEnd.position.z), Quaternion.identity, parent);
        rightSide.SetActive(false);
        Destroy(this);
    }

}
