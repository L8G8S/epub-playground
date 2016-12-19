using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Devcorp.Epub
{
    /// <summary>
    /// The open container is used to map the content of a OpenPublication to a .epub file.
    /// </summary>
    /// <remarks>http://www.idpf.org/epub/301/spec/epub-ocf.html</remarks>
    public class OpenContainer
    {
        public OpenContainer(string file)
        {
            this.File = file;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf</remarks>
        private void LoadContainer() 
        {
            var xdoc = XDocument.Load("container.xml");

            var namespaceManager = new XmlNamespaceManager(new NameTable());
            namespaceManager.AddNamespace("ocf", "urn:oasis:names:tc:opendocument:xmlns:container");

            //var rootQuery = (from xTag in xdoc.Descendants("rootfile") select xTag);
            var rootfiles = xdoc.XPathSelectElements("/ocf:container/ocf:rootfiles/ocf:rootfile", namespaceManager);
            foreach(var rootFile in rootfiles) 
            {
                // full-path
                // media-type
            }

            //var linkQuery = (from xTag in xdoc.Descendants("link") select xTag);
            var links = xdoc.XPathSelectElements("/ocf:container/ocf:links/ocf:link", namespaceManager);
            foreach(var link in links) 
            {
                // href
                // rel
                // media-type
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf-encryption.xml</remarks>
        private void LoadEncryption() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf-manifest.xml</remarks>
        private void LoadManifest() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf-metadata.xml</remarks>
        private void LoadMetadata() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf-signatures.xml</remarks>
        private void LoadSignatures() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>see http://www.idpf.org/epub/301/spec/epub-ocf.html#sec-container-metainf-rights.xml</remarks>
        private void LoadRights() 
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadMimeType() 
        {
            // this file only contains application/epub+zip (normally)
        }

        public void Load() 
        {
            // load all the ressources in META-INF
            LoadContainer();
            LoadEncryption();
            LoadManifest();
            LoadMetadata();
            LoadSignatures();
            LoadRights();

            // load information from mimetype file
            LoadMimeType();
        }

        public void Save() 
        {
            // The OCF Abstract Container must include a directory named META-INF that is a direct child of the container's root directory.
            // All OCF Containers must include a file called container.xml within the META-INF directory.

            // The file name mimetype in the root directory is reserved for use by OCF ZIP Containers
        }

        /// <summary>
        /// Gets the file related to this container.
        /// </summary>
        public string File 
        {
            get;
            private set;
        }
    }
}
