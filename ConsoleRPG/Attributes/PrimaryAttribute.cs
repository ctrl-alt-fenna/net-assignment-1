namespace Assignment1.Attributes
{
    public class PrimaryAttribute
    {
        public double Strength { get; set; }
        public double Dexterity { get; set; }
        public double Intelligence { get; set; }
        /// <summary>
        /// Overloads the + operator so adding of PrimaryAttributes is easier
        /// </summary>
        /// <param name="leftHandSide">Left side of addition equation</param>
        /// <param name="rightHandSide">Right side of addition</param>
        /// <returns>A new PrimaryAttribute object with the attributes of left and right side added</returns>
        public static PrimaryAttribute operator +(PrimaryAttribute leftHandSide, PrimaryAttribute rightHandSide)
        {
            return new PrimaryAttribute
            {
                Strength = leftHandSide.Strength + rightHandSide.Strength,
                Dexterity = leftHandSide.Dexterity + rightHandSide.Dexterity,
                Intelligence = leftHandSide.Intelligence + rightHandSide.Intelligence
            };
        }
        /// <summary>
        /// Overloads the - operator so subtracting PrimaryAttributes is easier
        /// </summary>
        /// <param name="leftHandSide">Left side of subtraction equation</param>
        /// <param name="rightHandSide">Right side of subtraction </param>
        /// <returns>A new PrimaryAttribute object with the attributes of left and right side subtracted</returns>
        public static PrimaryAttribute operator -(PrimaryAttribute leftHandSide, PrimaryAttribute rightHandSide)
        {
            return new PrimaryAttribute
            {
                Strength = leftHandSide.Strength - rightHandSide.Strength,
                Dexterity = leftHandSide.Dexterity - rightHandSide.Dexterity,
                Intelligence = leftHandSide.Intelligence - rightHandSide.Intelligence
            };
        }
        /// <summary>
        /// Function to make comparing of PrimaryAttributes easier.
        /// </summary>
        /// <param name="rightHandSide">PrimaryAttribute to compare to</param>
        /// <returns>True if all attributes are the same value, false if not</returns>
        public bool IsEqual(PrimaryAttribute rightHandSide)
        {
            return Strength == rightHandSide.Strength &&
                   Dexterity == rightHandSide.Dexterity &&
                   Intelligence == rightHandSide.Intelligence;
        }

    }
}
