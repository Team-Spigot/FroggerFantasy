using System.Collections.Generic;
using Tiled2Unity;
using UnityEditor;
using UnityEngine;

[CustomTiledImporter]
public class CustomLightImporter : ICustomTiledImporter
{

    // A game object within the prefab has some custom properties assigned through Tiled that are not consumed by Tiled2Unity
    // This callback gives customized importers a chance to react to such properties.
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
    }

    // Called just before the prefab is saved to the asset database
    // A last chance opportunity to modify it through script
    public void CustomizePrefab(GameObject prefab)
    {
        foreach (Transform child in prefab.transform.FindChild("Torches"))
        {
            //Debug.Log("Child found.");
            if (child.gameObject.tag == "Torch")
            {
                //Debug.Log("Child Matches");
                GameObject tempLight = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Torch.prefab", typeof(GameObject)));
                tempLight.transform.SetParent(child.transform);
                tempLight.transform.localPosition = new Vector3(16, 18, -125);
            }
        }
    }
}

