using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public interface ISearcher<T>
    {
        Solution search(ISearchable<T> searchable);
        int getNumberOfNodesEvaluated();
    }
}
