using System;

namespace Bit_Operations
{
	/// <summary>
	/// Specifies comparison signs: less than, more than and equals.
	/// </summary>
	[Flags]
    public enum ComparisonSigns
    {
        /// <summary>
        /// Specifies comparison sign: less than.
        /// </summary>
        LessThan = 1,

        /// <summary>
        /// Specifies comparison sign: more.
        /// </summary>
        MoreThan = 2,

        /// <summary>
        /// Specifies comparison sign: equals.
        /// </summary>
        Equals = 4,
    }
}
