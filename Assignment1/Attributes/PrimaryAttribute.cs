namespace Assignment1.Attributes
{
    public class PrimaryAttribute
    {
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Intelligence { get; set; }
        public static PrimaryAttribute operator +(PrimaryAttribute leftHandSide, PrimaryAttribute rightHandSide)
        {
            return new PrimaryAttribute
            {
                Strength = leftHandSide.Strength + rightHandSide.Strength,
                Dexterity = leftHandSide.Dexterity + rightHandSide.Dexterity,
                Intelligence = leftHandSide.Intelligence + rightHandSide.Intelligence
            };
        }
        public static PrimaryAttribute operator -(PrimaryAttribute leftHandSide, PrimaryAttribute rightHandSide)
        {
            return new PrimaryAttribute
            {
                Strength = leftHandSide.Strength - rightHandSide.Strength,
                Dexterity = leftHandSide.Dexterity - rightHandSide.Dexterity,
                Intelligence = leftHandSide.Intelligence - rightHandSide.Intelligence
            };
        }
        public bool IsEqual(PrimaryAttribute rightHandSide)
        {
            return Strength == rightHandSide.Strength &&
                   Dexterity == rightHandSide.Dexterity &&
                   Intelligence == rightHandSide.Intelligence;
        }

    }
}
