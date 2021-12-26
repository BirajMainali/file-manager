using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace FileManager.Web.Providers
{
    public class CustomFileProvider : IFileProvider
    {
        private readonly string _root;
        private PhysicalFileProvider _provider;

        public CustomFileProvider(string root)
        {
            _root = root;
            SetProvider();
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return GetProvider().GetDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return GetProvider().GetFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return GetProvider().Watch(filter);
        }

        private void SetProvider()
        {
            if (!Directory.Exists(_root)) Directory.CreateDirectory(_root);

            if (_provider == null) _provider = new PhysicalFileProvider(_root);
        }

        private IFileProvider GetProvider()
        {
            return _provider;
        }
    }
}