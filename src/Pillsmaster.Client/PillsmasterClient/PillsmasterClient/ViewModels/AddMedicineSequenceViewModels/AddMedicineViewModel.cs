using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using PillsmasterClient.Models.MedicineModels;
using PillsmasterClient.Models.TakeModels;
using PillsmasterClient.Models.UserMedicineModels;
using PillsmasterClient.Views.AddMedicineSequence;

using Xamarin.Forms;

namespace PillsmasterClient.ViewModels.AddMedicineSequenceViewModels
{
    public class AddMedicineViewModel : BaseViewModel
    {
        public IAsyncCommand GoNextAsyncCommand { get; }

        private string tradeName;
        public string TradeName
        {
            get => tradeName;
            set => SetProperty(ref tradeName, value);
        }

        private string internationalName;

        public string InternationalName
        {
            get => internationalName;
            set => SetProperty(ref internationalName, value);
        }

        private string pharmaType;

        public string PharmaType
        {
            get => pharmaType;
            set
            {
                SetProperty(ref pharmaType, value);
                if (value == "Таблеки")
                    pharmaTypeId = 1;
                else if (value == "Капсулы")
                    pharmaTypeId = 2;
            }
        }

        private int activeIngredientCount;

        public int ActiveIngredientCount
        {
            get => activeIngredientCount;
            set => SetProperty(ref activeIngredientCount, value);
        }

        private int pharmaTypeId;


        public AddMedicineViewModel()
        {
            GoNextAsyncCommand = new AsyncCommand(OnNextClicked);
        }

        public async Task OnNextClicked()
        {
            if (TradeName != null && InternationalName != null && PharmaType != null && ActiveIngredientCount > 0)
            {
                var userMedicineRequest = new UserMedecineRequest()
                {
                    TradeName = TradeName,
                    InternationalName = InternationalName,
                    PharmaTypeId = pharmaTypeId,
                    ActiveIngredientCount = ActiveIngredientCount
                };

                var json = JsonConvert.SerializeObject(userMedicineRequest);

                await Shell.Current.GoToAsync($"{nameof(AddMedicationDayPage)}?UserMedicineRequest={json}");
                return;
            }

            await Shell.Current.DisplayAlert("Не все поля заполнены!", "Заполните все поля.", "Ок")
                .ConfigureAwait(false);
        }
    }
}
