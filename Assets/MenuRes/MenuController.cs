using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    int selectedLavelindex;
    string GEOMETRY_TYPE = "geomType";
    string GROW_CURVATURE = "doGrowCurveture";

    public void Paly()
    {
        SceneManager.LoadScene(selectedLavelindex + 1);
    }

    public void LevelChanged(int val) {
        selectedLavelindex = val;
    }

    public void GeomTypeChanged(int val)
    {
        if (val == 0)
        {
            PlayerPrefs.SetInt(GEOMETRY_TYPE, (int)GeometryControl.Geometry.Hyperbolic);
            PlayerPrefs.SetInt(GROW_CURVATURE, (int) GeometryControl.CurvatureGrowing.Disabled);
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
