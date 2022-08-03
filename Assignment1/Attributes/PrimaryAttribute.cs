namespace Assignment1.Attributes
{
    public class PrimaryAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
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

    }
}
