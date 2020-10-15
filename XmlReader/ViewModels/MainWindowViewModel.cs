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
		public MainWindowViewModel()
		{
			XmlTreeViewModel = new XmlTreeViewModel();
			ApplyXPathRequestCommand = new RelayCommand(ApplyXPathRequest);
			OpenFileCommand = new RelayCommand(OpenFile);
		}

		public void ApplyXPathRequest()
		{
			if (XmlTreeViewModel?.XmlDocument == null)
				return;

			if (String.IsNullOrEmpty(XPathRequest))
			{
				XmlTreeViewModel.DeleteXPathRequest();
				return;
			}

			XmlTreeViewModel.ApplyXPathRequest(XPathRequest);
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
