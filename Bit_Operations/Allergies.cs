using System;
using System.Collections.Generic;

namespace Bit_Operations
{
	public class Allergies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        private readonly int x;

        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException(message: $"Size of matrix '{score}' cannot be less than zero.");
            }

            this.x = score;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            Allergens[] allergensList = this.AllergensList();
            bool answer = false;
            if (allergensList == Array.Empty<Allergens>())
            {
                return answer;
            }

            for (int i = 0; i < allergensList.Length; i++)
            {
                if (allergens.HasFlag(allergensList[i]))
                {
                    answer = true;
                }
            }

            return answer;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> list = new List<Allergens>();
            Allergens[] allergensArr = (Allergens[])Enum.GetValues(typeof(Allergens));
            for (int i = 0; i < allergensArr.Length; i++)
            {
                if (((int)allergensArr[i] & this.x) != 0)
                {
                    list.Add(allergensArr[i]);
                }
            }

            return list.ToArray();
        }
    }
}
