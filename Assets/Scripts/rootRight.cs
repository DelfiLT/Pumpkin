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
        pumpkingScript pumpkingPaternScript = GetComponentInParent<pumpkingScript>();
        if (pumpkingPaternScript.rootLevel < 5)
        {
            fx_createBranch.playFX();
            Transform parent = GetComponentInParent<Transform>();
            GameObject root = Instantiate(roots[Random.Range(0, roots.Length)], new Vector3(rightEnd.position.x, rightEnd.position.y, rightEnd.position.z), Quaternion.identity, parent);
            leftSide.SetActive(false);
            pumpkingPaternScript.rootLevel += 1;
            Destroy(this);
        }
    }
}
