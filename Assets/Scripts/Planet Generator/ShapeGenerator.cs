using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    ShapeSettings settings;
    NoiseFilter [] noiseFilters;
    public MinMax elevationMinMax;

    public void UpdateSettings (ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilters = new NoiseFilter[settings.noiseLayers.Length];

        for (int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = new NoiseFilter(settings.noiseLayers[i].noiseSettings);
        }
        elevationMinMax = new MinMax();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 1;
        float elevation = 0;

        if (noiseFilters.Length > 1)
        {
            firstLayerValue = noiseFilters[1].Evaluate(pointOnUnitSphere); //definimos la segunda capa como máscara
            if (settings.noiseLayers[1].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for (int i = 2; i < noiseFilters.Length; i++)
        {
            if (settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 2;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }
        elevation = settings.planetRadius * (1 + elevation);
        elevationMinMax.AddValue(elevation); //álturas máximas y mínimas de los vértices del polígono
        return pointOnUnitSphere * elevation;
    }

}
