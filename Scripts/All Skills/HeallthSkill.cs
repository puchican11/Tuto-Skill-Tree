using Puchican;
using UnityEngine;

public class HeallthSkill : Skill
{
    public float HealthAmount;
    public float Duration;
    float temp;

    public override void OnStart()
    {
        base.OnStart();
        SkillManager.Instance.Health += HealthAmount;
        temp = Duration;
        IsLaunched = true;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(temp > 0)
        {
            temp -= Time.deltaTime;
        }

        if (temp <= 0)
        {
            OnComplete();
        }
    }

    public override void OnComplete()
    {
        base.OnComplete();
        SkillManager.Instance.Health -= HealthAmount;
        IsLaunched = false;
    }
}
