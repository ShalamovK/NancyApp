using Nancy;
using System.IO;
using System.Reflection;

namespace NancyApp.AppStart {
    public class RootPathConfig : IRootPathProvider {
        public string GetRootPath() {
            var root = Assembly.GetExecutingAssembly().Location;
            var path = Path.GetFullPath(Path.Combine(root, @"..\..\..\"));

            return path;
        }
    }
}
