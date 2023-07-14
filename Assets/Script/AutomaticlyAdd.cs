using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;

public class AutomaticlyAdd : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private ClippingPlane clipping;
   
    // Start is called before the first frame update
    void Start()
    {
        GetRenderRecursive(obj);
    }

    private void GetRenderRecursive(GameObject o)
    {
        var renderer = o.GetComponent<MeshRenderer>();
        if (renderer != null) clipping.AddRenderer(renderer);

        if (o.transform.childCount == 0) return;
        for(int i=0; i<o.transform.childCount; i++)
        {
            GetRenderRecursive(o.transform.GetChild(i).gameObject);
        }
    }

   
   
}
