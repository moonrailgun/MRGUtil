using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRGUtil
{
    public abstract class MRGUtil : IUtil
    {
        protected abstract string releaseVersion = "1.0.0";
        protected abstract string internalVersion = "20150906";

        public string GetVersion()
        {
            return this.releaseVersion;
        }

        public string GetInternalVersion()
        {
            return this.internalVersion;
        }
    }
}
