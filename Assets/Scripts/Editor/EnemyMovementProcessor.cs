using UnityEngine;
using System.Collections.Generic;
using Tiled2Unity;
using UnityEditor;
using TeamSpigot;

[CustomTiledImporter]
public class EnemyMovementProcessor : ICustomTiledImporter
{
    // A game object within the prefab has some custom properites assigned through Tiled that are not consumed by Tiled2Unity
    // This callback gives customized importers a chance to react to such properites.
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (customProperties.ContainsKey("ff:enemy"))
        {
            GameObject tempEnemy = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/OverworldEnemy.prefab", typeof(GameObject)));
            if (customProperties.ContainsKey("ff:movement"))
            {
                switch (customProperties["ff:movement"])
                {
                    case "up":
                        tempEnemy.GetComponent<EnemyMovement>().direction = EnemyMovement.Direction.up;
                        break;
                    case "left":
                        tempEnemy.GetComponent<EnemyMovement>().direction = EnemyMovement.Direction.left;
                        break;
                    case "down":
                        tempEnemy.GetComponent<EnemyMovement>().direction = EnemyMovement.Direction.down;
                        break;
                    case "right":
                        tempEnemy.GetComponent<EnemyMovement>().direction = EnemyMovement.Direction.right;
                        break;
                    default:
                        Debug.LogError("\"ff:movement\" property doesn't contain correct value");
                        return;
                }
            }
            tempEnemy.name = "OverworldEnemy" + customProperties["ff:enemy"];
            tempEnemy.transform.SetParent(gameObject.transform);
            tempEnemy.transform.localPosition = new Vector3(0, -32, 0);
        }
    }

    // Called just before the prefab is saved to the asset database
    // A last chance opporunity to modify it through script
    public void CustomizePrefab(GameObject prefab)
    {

    }
}
