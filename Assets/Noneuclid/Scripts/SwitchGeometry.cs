using UnityEngine;

public class SwitchGeometry : MonoBehaviour
{
    GeometryControl geomControl;

    bool downScalingEnabled = false;
    float downscalingSpeed = 0.001f;

    void Start()
    {
        if (geomControl == null)
        {
            geomControl = FindObjectOfType<GeometryControl>();
        }
        if (geomControl == null)
        {
            enabled = false;
        }
        else
        {
            int geomTypeIdx = PlayerPrefs.GetInt("geomType");
            if (geomTypeIdx == (int)GeometryControl.Geometry.Euclidean)
            {
                geomControl.geometry = GeometryControl.Geometry.Euclidean;
            }
            if (geomTypeIdx == (int)GeometryControl.Geometry.Elliptic)
            {
                geomControl.geometry = GeometryControl.Geometry.Elliptic;
            }

            if (geomTypeIdx == (int)GeometryControl.Geometry.Hyperbolic)
            {
                geomControl.geometry = GeometryControl.Geometry.Hyperbolic;
            }
            downScalingEnabled = PlayerPrefs.GetInt("doGrowCurveture") == (int)GeometryControl.CurvatureGrowing.Enabled;
            if(downScalingEnabled)
            {
                geomControl.globalScale *= 0.01f;
            }
        }
    }

    void Update()
    {
        if (downScalingEnabled) {
            float dt = Time.deltaTime;
            geomControl.globalScale += dt * downscalingSpeed;
        }
    }
}
