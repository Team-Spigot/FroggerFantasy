using System.Collections.Generic;
using Tiled2Unity;
using UnityEditor;
using TeamSpigot;
using UnityEngine;

[CustomTiledImporter]
public class CustomDropOffPointImporter : ICustomTiledImporter
{

    // A game object within the prefab has some custom properties assigned through Tiled that are not consumed by Tiled2Unity
    // This callback gives customized importers a chance to react to such properties.
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (customProperties.ContainsKey("ff:dropOff"))
        {
            GameObject tempObject = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/DropOffPoint.prefab", typeof(GameObject)));
            tempObject.transform.SetParent(gameObject.transform);
            tempObject.transform.localPosition = Vector3.zero;
            tempObject.GetComponent<DropOffPoint>().DropPointNum = customProperties["ff:dropOff"];
        }
    }

    // Called just before the prefab is saved to the asset database
    // A last chance opportunity to modify it through script
    public void CustomizePrefab(GameObject prefab)
    {
    }
}

