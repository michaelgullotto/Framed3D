using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class andrewscode : MonoBehaviour
{
   void LimitFramerate(int target)
   {
      Application.targetFrameRate = target;

      Resolution[] allowedRes = Screen.resolutions;

      Resolution res = new Resolution();

      res.height = 1080;
      res.width = 1920;
      res.refreshRate = Screen.currentResolution.refreshRate;

      //Screen.SetResolution(allowedRes[selec]);
   }
}
