using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;

    public GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndicies = new List<Vector3>();

    public LaserBeam(Vector3 pos, Vector3 dir, Material material, Material laserMaterial) {
        laser = new LineRenderer();
        laserObj = new GameObject();
        laserObj.name = "Laser Beam";

        this.pos = pos;
        this.dir = dir;

        laser = laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = 0.1f;
        laser.endWidth = 0.1f;
        laser.material = material;
        laser.startColor = Color.clear;
        laser.endColor = Color.clear;

        CastRay(pos, dir, laser);

        //get mesh and use that
       laserObj.AddComponent(typeof(MeshFilter));
        MeshFilter mesh = laserObj.GetComponent<MeshFilter>();
        laser.BakeMesh(mesh.mesh);
        mesh.mesh.colors = null;
        MeshRenderer meshRenderer = laserObj.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        meshRenderer.material = laserMaterial;
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndicies.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            laserIndicies.Add(hit.point);
            UpdateLaser();
        }
        else
        {
            laserIndicies.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndicies.Count;
        foreach (Vector3 idx in laserIndicies) 
        {
            laser.SetPosition(count, idx);
            count ++;
        }
    }

}
