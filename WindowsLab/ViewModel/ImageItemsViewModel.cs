using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgShare.APISource.Data.ImgurResponseModels;
using ImgShare.APISource.Data;
using WindowsLab.Utility;

namespace WindowsLab.ViewModel
{
    class ImageItemsViewModel
    {
        public ObservableCollection<Image> ImageItems { get; set; }

        public async Task<ObservableCollection<Image>> GetImages()
        {
            ImageItems = new ObservableCollection<Image>();
            ImageItems.Clear();

            ImgurGalleryImageList list = await ImgurApiSource.Instance.GalleryDetailsAsync(GallerySection.hot, GallerySort.viral, 0);

            foreach (ImgurGalleryImage TempImg in list.Images)
                if (Constants.ImageExtensions.Any(TempImg.LinkThumbnail320x320.ToString().EndsWith))
                    ImageItems.Add(new Image { ImageUri = new Uri(TempImg.LinkThumbnail320x320) });

            return ImageItems;
        }
    }
}
