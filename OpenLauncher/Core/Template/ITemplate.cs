using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLauncher.Core.Template
{
    public interface  ITemplate
    {
        /// <summary>
        /// This will set a template file for the current template class
        /// </summary>
        /// <param name="filename">The path to the template file</param>
        void SetTemplateFile(string filename);

        /// <summary>
        /// This will add a replacement string to the class. This will be done as soon as you Get() the result of the finished template
        /// </summary>
        /// <param name="needle">The needle to replace</param>
        /// <param name="replacement">The value to set instead of the needle</param>
        void AddReplacement(string needle, string replacement);

        /// <summary>
        /// This will return the filled template as string
        /// </summary>
        /// <returns>The template as a string ready to use</returns>
        string Get();
    }
}
