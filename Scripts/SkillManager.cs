using Puchican;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skill[] SkillList;
    public Skill CurrentSkill;

    public float Health = 0;
    public float Money = 0;

    public ToolTip ToolTip;

    public static SkillManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (CurrentSkill == null) return;

        if(Input.GetKeyDown(KeyCode.Escape) && CurrentSkill.IsUnlocked)
        {
            StartAbility();
        }

        if(CurrentSkill.IsUnlocked && CurrentSkill.IsLaunched)
        {
            UpdateAbility();
        }
    }

    public void StartAbility()
    {
        CurrentSkill.StartAbiltity();
    }

    public void UpdateAbility()
    {
        CurrentSkill.OnUpdate();
    }

    public void CompleteAbility()
    {
        CurrentSkill.OnComplete();
    }

    public void UnlockSkill(Skill s)
    {
        Skill skill = SkillList.Where(elem => elem.SkillName == s.SkillName).FirstOrDefault();
        if (skill == null) return;

        skill.IsUnlocked = true;
        CurrentSkill = skill;
        Money -= skill.CostMoney;
        Debug.Log($"{skill.SkillName} est débloqué");
        ToolTip.gameObject.SetActive(false);
    }

    public void ShowToolTip(SkillItem skillItem)
    {
        ToolTip.gameObject.SetActive(true);
        ToolTip.Setup(skillItem);
    }
}
