using Ninject;
using Samples.ViewModels;
using Xamarin.Forms;

namespace Samples.Views
{

    public partial class SignatureListView : ContentPage {

        public SignatureListView() {
            this.BindingContext = App.Kernel.Get<SignatureListViewModel>();
            InitializeComponent();
			this.ListView.ItemSelected += (sender, e) => {
				if (e.SelectedItem == null)
					return;

				((SignatureListViewModel)this.BindingContext).Select.Execute(e.SelectedItem);

                ((ListView)sender).SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<SignatureListView>(this, "Appearing");
        }
    }
}
