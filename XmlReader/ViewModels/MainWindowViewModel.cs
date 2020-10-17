using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace XmlReader.ViewModels
{
	class MainWindowViewModel : ViewModelBase
	{
		public XmlTreeViewModel XmlTreeViewModel { get; private set; }
		public string XPathRequest { get; set; }
		public ICommand ApplyXPathRequestCommand { get; }
		public ICommand OpenFileCommand { get; }

		private bool _xPathIsIncorrect;
		public bool XPathIsIncorrect
		{
			get => this._xPathIsIncorrect;
			private set
			{
				_xPathIsIncorrect = value;
				RaisePropertyChanged(nameof(XPathIsIncorrect));
			}
		}

		public MainWindowViewModel()
		{
			XmlTreeViewModel = new XmlTreeViewModel();
			ApplyXPathRequestCommand = new RelayCommand(ApplyXPathRequest);
			OpenFileCommand = new RelayCommand(OpenFile);
			XPathIsIncorrect = false;
		}

		public void ApplyXPathRequest()
		{
			XPathIsIncorrect = false; // by default we suppose, that given XPath is fine

			if (XmlTreeViewModel?.XmlDocument == null)
				return;

			if (String.IsNullOrEmpty(XPathRequest))
			{
				XmlTreeViewModel.DeleteXPathRequest();
				return;
			}

			XPathIsIncorrect = !XmlTreeViewModel.ApplyXPathRequest(XPathRequest);
		}

		public void OpenFile()
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				XmlTreeViewModel.LoadDocument(openFileDialog.FileName);
			}
		}
	}
}
