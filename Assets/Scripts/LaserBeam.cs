using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;

    public GameObject laserObj;
    public bool goalReached = false;
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
        addLaserIndex(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            addLaserIndex(ray.GetPoint(30));
        }
    }


    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.tag == "Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else if (hitInfo.collider.tag == "LaserIgnore")
        {
            CastRay(hitInfo.point + direction.normalized*0.05f, direction, laser);
        }
        else
        {
            addLaserIndex(hitInfo.point);
        }

        if (hitInfo.collider.tag == "Goal")
        {
            goalReached = true;
        }
    
    }


    //add with resolution, becaus the line is not straight in curved spaces
    void addLaserIndex(Vector3 next)
    {
        const float resolution = 0.1f;
        if (laserIndicies.Count > 0)
        {
            Vector3 last = laserIndicies[laserIndicies.Count -1];
            Vector3 difference = next - last;
            float distance = difference.magnitude;
            Vector3 dir = difference.normalized;
            for (float i = resolution; i <= distance; i += resolution)
            {
                laserIndicies.Add(last + i * dir);
            }
            laserIndicies.Add(next);
        }
        else
        {
            laserIndicies.Add(next);
        }
        UpdateLaser();
    
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndicies.Count;
        foreach (Vector3 idx in laserIndicies)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

}
