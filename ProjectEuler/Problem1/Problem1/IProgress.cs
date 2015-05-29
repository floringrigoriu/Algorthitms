using System;

namespace Problem1
{
    public interface IProgress
    {
        // maximum value @ progress
        int Max { get; }

        // Progress is on the way
        event EventHandler<int> ProgressUpdated;
       
        // computation done - big way
        event EventHandler ProgressCompleted;
    }
}
