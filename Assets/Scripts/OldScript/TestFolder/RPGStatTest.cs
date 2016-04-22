using UnityEngine;
using System.Collections;
using System;

public class RPGStatTest : MonoBehaviour {
    private RPGStatCollection stats;


    void Start()
    {
        stats = new RPGDefaultStats();

        DisplayStatValues();

        var health = stats.GetStat<RPGStatModifiable>(RPGStatType.Health);
        //var vitality = stats.GetStat<RPGStatModifiable>(RPGStatType.Vitality);
        var strength = stats.GetStat<RPGStatModifiable>(RPGStatType.Strength);
        strength.AddModifier(new RPGStatModifier(RPGStatType.Strength, RPGStatModifier.Types.BaseValueAdd, UnityEngine.Random.Range(-3, 3)));
        //health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValuePercent, 1.0f)); //200
        //health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValueAdd, 20 * vitality.StatBaseValue)); // 250
        //health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.TotalValuePercent, 1.0f)); // 500
        health.UpdateModifiers();

        DisplayStatValues();
    }
    

    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<RPGStatType>((statType) => {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}", stat.StatName, stat.StatValue));
            }
        });
    }

}
