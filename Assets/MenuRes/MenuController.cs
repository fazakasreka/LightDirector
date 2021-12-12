using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    int selectedLevelindex = 0;
    string GEOMETRY_TYPE = "geomType";
    string GROW_CURVATURE = "doGrowCurveture";

    private void Start()
    {
        GeomTypeChanged(0);
    }

    public void Paly()
    {
        SceneManager.LoadScene(selectedLevelindex + 1);
    }

    public void LevelChanged(int val) {
        selectedLevelindex = val;
    }

    public void GeomTypeChanged(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Hyperbolic);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int) GeometryControl.CurvatureGrowing.Disabled);
            print("lol");
        }
        else if (val == 1)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Elliptic);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int)GeometryControl.CurvatureGrowing.Disabled);
        }
        else if (val == 2)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Euclidean);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int)GeometryControl.CurvatureGrowing.Disabled);
        }
        else if (val == 3)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Hyperbolic);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int)GeometryControl.CurvatureGrowing.Enabled);
        }
        else if (val == 4)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Elliptic);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int)GeometryControl.CurvatureGrowing.Enabled);
        }
    }
}
