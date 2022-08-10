using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using Newtonsoft.Json;
using PillsmasterClient.Models.MedicineModels;
using PillsmasterClient.Models.TakeModels;
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
            set => SetProperty(ref pharmaType, value);
        }

        private int activeIngredientCount;

        public int ActiveIngredientCount
        {
            get => activeIngredientCount;
            set => SetProperty(ref activeIngredientCount, value);
        }

        private MedicineRequest medicine;
        public IAsyncCommand GoNextAsync;

        public MedicineRequest Medicine
        {
            get => medicine;
            set => SetProperty(ref medicine, value);
        }

        public AddMedicineViewModel()
        {
            GoNextAsyncCommand = new AsyncCommand(OnNextClicked);
        }

        public async Task OnNextClicked()
        {
            if (TradeName != null && InternationalName != null && PharmaType != null && ActiveIngredientCount != null)
            {
                var medicineRequest = new MedicineRequest()
                {
                    TradeName = TradeName,
                    InternationalName = InternationalName,
                    PharmaType = PharmaType,
                    ActiveIngredientCount = ActiveIngredientCount
                };

                var json = JsonConvert.SerializeObject(medicineRequest);

                await Shell.Current.GoToAsync($"{nameof(AddMedicationDayPage)}?MedicineRequest={json}");
                return;
            }

            await Shell.Current.DisplayAlert("Не все поля заполнены!", "Заполните все поля.", "Ок")
                .ConfigureAwait(false);
        }
    }
}
