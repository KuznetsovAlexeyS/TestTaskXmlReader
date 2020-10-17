using GalaSoft.MvvmLight;
using System.Xml;
using XmlReader.Models;

namespace XmlReader.ViewModels
{
	public class XmlTreeViewModel : ViewModelBase
	{
		private XmlTreeModel _xmlTreeModel;
		public XmlTreeModel XmlTreeModel 
		{
			get => this._xmlTreeModel;
			set
			{
				_xmlTreeModel = value;
				RaisePropertyChanged(nameof(XmlTreeModel));
			}
		}

		public XmlDocument XmlDocument { get => XmlTreeModel.LoadedDocument; }

		private XmlNodeList _xPathSearchResult;
		public XmlNodeList XPathSearchResult 
		{
			get => this._xPathSearchResult; 
			private set
			{
				_xPathSearchResult = value;
				RaisePropertyChanged(nameof(XPathSearchResult));
			}
		}

		private bool _isInSearchMode;
		public bool IsInSearchMode
		{
			get => this._isInSearchMode;
			private set
			{
				_isInSearchMode = value;
				RaisePropertyChanged(nameof(IsInSearchMode));
			}
		}

		public XmlTreeViewModel()
		{
			XmlTreeModel = new XmlTreeModel();
		}

		public bool LoadDocument(string path)
		{
			try
			{
				XmlTreeModel.LoadDocument(path);
				RaisePropertyChanged(nameof(XmlDocument));
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool ApplyXPathRequest(string XPathRequest)
		{
			try
			{
				IsInSearchMode = true;
				XPathSearchResult = XmlDocument.SelectNodes(XPathRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void DeleteXPathRequest()
		{
			IsInSearchMode = false;
			XPathSearchResult = null;
		}
	}
}
