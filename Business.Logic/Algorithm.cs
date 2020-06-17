using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic
{
    public abstract class Algorithm<OutputT>
    {
        protected abstract void OnValidate(string input);

        protected abstract OutputT OnPerform(string input);

        public OutputT Run(string input)
        {
            OnValidate(input);
            return OnPerform(input);
        }
    }
}
