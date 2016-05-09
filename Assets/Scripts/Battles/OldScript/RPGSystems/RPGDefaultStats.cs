using UnityEngine;
using System.Collections;

public class RPGDefaultStats : RPGStatCollection
{
    protected override void ConfigureStats()
    {
        var vitality = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Vitality);
        vitality.StatName = "Vitality";
        vitality.StatBaseValue = 5;

        var strength = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Strength);
        strength.StatName = "Strength";
        strength.StatBaseValue = UnityEngine.Random.Range(-3, 3);

        var agility = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Agility);
        agility.StatName = "Agility";
        agility.StatBaseValue = 5;

        var aim = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Aim);
        aim.StatName = "Aim";
        aim.StatBaseValue = 5;

        var angst = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Angst);
        angst.StatName = "Angst";
        angst.StatBaseValue = 5;

        var empathy = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Empathy);
        empathy.StatName = "Empathy";
        empathy.StatBaseValue = 5;

        var skill = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Skill);
        skill.StatName = "Skill";
        skill.StatBaseValue = 5;

        var luck = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Luck);
        luck.StatName = "Luck";
        luck.StatBaseValue = 5;


        var health = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;

        var Mana = CreateOrGetStat<RPGStatModifiable>(RPGStatType.Mana);
        Mana.StatName = "Mana";
        Mana.StatBaseValue = 50;
    }
}
