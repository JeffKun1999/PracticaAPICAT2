using PracticaAPICAT2.ViewModels;
namespace PracticaAPICAT2.Views;

public partial class CatImagePage : ContentPage
{
	public CatImagePage()
	{
		InitializeComponent();
        BindingContext = new CatImageViewModel();

    }
}