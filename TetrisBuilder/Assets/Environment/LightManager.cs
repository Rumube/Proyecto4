using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{
    /* public float velocidad;
     private void Update()
     {
         transform.Rotate(velocidad * Time.deltaTime, 0, 0);
         if (transform.eulerAngles.x == 0)
         {Debug.Log("EY");
             City.day= City.day + 1;
         }
     }
 }*/
    //References
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightPresets DayPreset;
    [SerializeField] private LightPresets NightPreset;
    [SerializeField] private LightPresets EveningPreset;
    //Variables
    [SerializeField, Range(0,24)] private float hour;

    private void Update()
    {
        if (hour > 0.998f && hour <= 1f )
        {
            City.day = City.day + 1;
        }
        if (DayPreset == null)
            return;

        if (Application.isPlaying)
        {
            hour += Time.deltaTime;
            hour %= 24;
            UpdateLighting(hour / 48);
        }
        else
        {
            UpdateLighting(hour / 48);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        if (hour >20 )
        {
            directionalLight.color = NightPreset.DirectionalColor.Evaluate(timePercent);
        }

        else if(hour > 5 && hour < 18)
        {
            directionalLight.color = DayPreset.DirectionalColor.Evaluate(timePercent);
        }
        else if (hour > 17 && hour < 21)
        {
            directionalLight.color = EveningPreset.DirectionalColor.Evaluate(timePercent);
        }
        else
        {
            directionalLight.color = NightPreset.DirectionalColor.Evaluate(timePercent);
        }

        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 0, 0));
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach  (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }

            }
        }
    }
}
