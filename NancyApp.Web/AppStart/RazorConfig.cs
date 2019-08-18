using Nancy.ViewEngines.Razor;
using System.Collections.Generic;

namespace NancyApp.AppStart {
    public class RazorConfig : IRazorConfiguration {
        public IEnumerable<string> GetAssemblyNames() {
            yield return "NancyApp";
            yield return "NancyApp.Common";
        }

        public IEnumerable<string> GetDefaultNamespaces() {
            yield return "NancyApp";
            yield return "NancyApp.Common.Dtos";
        }

        public bool AutoIncludeModelNamespace {
            get { return true; }
        }
    }
}
