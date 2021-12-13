using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Plane))]
public class FloorMaker : MonoBehaviour
{
    public Transform floorPrefab;
    public int spacingbetween;
    public int zWidth;
    public int xWidth;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = spacingbetween; x < xWidth * spacingbetween; x += spacingbetween)
        {
            for (int z = spacingbetween; z < zWidth * spacingbetween; z += spacingbetween)
            {
                print(x.ToString() + z.ToString());
                Transform newgate = GameObject.Instantiate(floorPrefab);
                newgate.transform.Translate(new Vector3(x, 0, z));
            }
        }
    }
}
