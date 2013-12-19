using System;
namespace Problem1
{
    /// <summary>
    /// Problem definition 
    /// </summary>
    interface IProblem<T>
    {
        /// <summary>
        /// what
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Do solve it
        /// </summary>
        long Solve(T limit);
    }
}
