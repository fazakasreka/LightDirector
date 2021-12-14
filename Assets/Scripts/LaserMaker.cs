using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMaker : MonoBehaviour
{
    public Material material;
    public Material laserMaterial;
    public GameObject LevelCompletedMenu;
    LaserBeam beam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(beam != null && beam.laserObj != null) Destroy(beam.laserObj);
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.up, material, laserMaterial);
        if (beam.goalReached)
        {
            LevelCompletedMenu.SetActive(true);
        }
        if (!beam.goalReached)
        {
            LevelCompletedMenu.SetActive(false);
        }
    }
}
