using UnityEngine;
using UnityEngine.UI;
using Puchican;

public class SkillItem : MonoBehaviour
{
    public Skill Skill;
    public Image Icon;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Icon.sprite = Skill.Icon;
    }

    public void ShowToolTip()
    {
         SkillManager.Instance.ShowToolTip(this);
    }

    public void UnlockSkill()
    {
        if (Skill.CanBeUnlocked())
        {
            SkillManager.Instance.UnlockSkill(Skill);
        }
    }
}
