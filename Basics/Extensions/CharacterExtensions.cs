namespace Basics.Extensions
{
    public static class CharacterExtensions
    {
        /// <summary>
        /// Repeats a <see cref="char"/> <paramref name="repetitions"/> times.
        /// </summary>
        /// <param name="character">The <see cref="char"/> to be repeated.</param>
        /// <param name="repetitions">The number of repititions of the input <see cref="char"/>.</param>
        /// <returns>The resulting <see cref="string"/>.</returns>
        public static string Repeat(this char character, int repetitions) => new string(character, repetitions);
    }
}