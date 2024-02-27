using UnityEngine;

namespace Part
{
    public enum FootSkill
    {
        DoubleJump,
        空中喷射,
        踏云行,
        闪电战术
    }
    
    public class Foot : Parts
    {
        public FootSkill footSkill;
    }
}