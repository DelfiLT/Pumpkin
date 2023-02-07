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
        pumpkingScript pumpkingPaternScript = GetComponentInParent<pumpkingScript>();
        if(pumpkingPaternScript.rootLevel < 5)
        {
            fx_createBranch.playFX();
            Transform parent = GetComponentInParent<Transform>();
            GameObject root = Instantiate(roots[Random.Range(0, roots.Length)], new Vector3(leftEnd.position.x, leftEnd.position.y, leftEnd.position.z), Quaternion.identity, parent);
            rightSide.SetActive(false);
            pumpkingPaternScript.rootLevel += 1;
            Destroy(this);
        }

    }

}
