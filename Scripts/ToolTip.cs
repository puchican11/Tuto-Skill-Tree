using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Puchican;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI SkillName;
    public TextMeshProUGUI SkillDescription;
    public Button UnlockButton;

    public void Setup(SkillItem skill)
    {
        SkillName.text = skill.Skill.SkillName;
        SkillDescription.text = skill.Skill.SkillDescription;

        if (skill.Skill.IsUnlocked)
        {
            UnlockButton.interactable = false;
            UnlockButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = $"Already Unlocked";
        } else
        {
            UnlockButton.interactable = true;
            UnlockButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = $"{skill.Skill.CostMoney} Gold";
        }

        UnlockButton.onClick.RemoveAllListeners();
        UnlockButton.onClick.AddListener(delegate { skill.UnlockSkill(); });
    }
}
