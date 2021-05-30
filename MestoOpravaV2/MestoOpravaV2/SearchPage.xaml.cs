using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MestoOpravaV2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        
        public SearchPage()
        {
            InitializeComponent();
            
        }
        
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        void onClickedProblem(object sender, EventArgs e)
        {
            
            var ID = (Frame) sender;
            int classIDD = int.Parse(ID.GetParent<StackLayout>().ClassId);
            Navigation.PushModalAsync(new ProblemsPageDetails(classIDD), true);

        }

        private void Search_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            IEnumerable<Problem> searchresult = ProblemMVM.GetSearchResult(Search.Text);
            CollectionView.ItemsSource = searchresult;

        }
    }
}