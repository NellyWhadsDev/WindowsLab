using ImgShare.APISource.Data.ImgurResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsLab.ViewModel;
using Windows.UI.Xaml.Controls;

namespace WindowsLab.UserControls
{
    public sealed partial class ImageList : UserControl
    {
        private ImageItemsViewModel vm = new ImageItemsViewModel();
        public ImageList()
        {
            InitializeComponent();
        }

        public async Task<Boolean> LoadImages()
        {
            ObservableCollection<ViewModel.Image> list = await vm.GetImages();
            DataContext = list;

            return true;
        }
    }
}
