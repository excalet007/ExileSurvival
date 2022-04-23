using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[ShowInInspector]
public class Skill
{
    public Battler Owner = null;
    public string SkillName = "";
    public int Level =  0;
    public Define.SkillType SkillType = Define.SkillType.None;
    public HashSet<Define.SkillTag> SkillTags = new HashSet<Define.SkillTag>();
}
