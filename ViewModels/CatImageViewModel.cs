using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaAPICAT2.Models;
using PracticaAPICAT2.Services;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Windows.Input;



namespace PracticaAPICAT2.ViewModels
{
    public class CatImageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CatImageViewModel()
        {
            LoadRandomCatImageCommand = new Command(async () => await LoadRandomCatImage());
        }

        private Uri imageUri;
        public Uri ImageUri
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private CatImageService service;
        public CatImageService Service
        {
            get
            {
                if (service == null)
                {
                    service = new CatImageService();
                }
                return service;
            }
        }

        public ICommand LoadRandomCatImageCommand { get; }

        private async Task LoadRandomCatImage()
        {
            CatImage catImage = await Service.GetRandomCatImage();
            if (catImage != null)
            {
                ImageUri = new Uri(catImage.Url);
            }
            else
            {
                ImageUri = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontrado-efecto-falla_8024-5.jpg");
            }
        }
    }
}