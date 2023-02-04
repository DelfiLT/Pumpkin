using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootRight : MonoBehaviour
{

    public GameObject[] roots;
    public Transform rightEnd;
    public GameObject leftSide;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Transform parent = GetComponentInParent<Transform>();
        GameObject root = Instantiate(roots[0], new Vector3(rightEnd.position.x, rightEnd.position.y, rightEnd.position.z), Quaternion.identity, parent);
        leftSide.SetActive(false);
        Destroy(this);
    }
}
