using System;
namespace Problem1
{
    /// <summary>
    /// Problem definition 
    /// </summary>
    interface IProblem
    {
        /// <summary>
        /// what
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Do solve it
        /// </summary>
        int Solve(int limit);
    }
}
