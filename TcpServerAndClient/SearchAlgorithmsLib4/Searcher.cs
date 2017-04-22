using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private int evaluatedNodes;
        protected string type;

        public Searcher()
        {
            evaluatedNodes = 0;
        }


        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public Solution search(ISearchable<T> searchable)
        {
            return new Solution(type);
        }
    }
}
