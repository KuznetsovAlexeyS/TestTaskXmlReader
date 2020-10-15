using System.Xml;

namespace XmlReader.Models
{
	public class XmlTreeModel
	{
		public XmlDocument LoadedDocument { get; private set; }

		public void LoadDocument(string path)
		{
			LoadedDocument = new XmlDocument();
			LoadedDocument.Load(path);
		}
	}
}
