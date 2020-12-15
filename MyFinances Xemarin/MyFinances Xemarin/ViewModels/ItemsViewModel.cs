﻿using MyFinances.Core.Dtos;
using MyFinances_Xemarin.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFinances_Xemarin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ObservableCollection<OperationDto> Operations { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteItemCommand { get; }

        public Command<OperationDto> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Operacje";
            Operations = new ObservableCollection<OperationDto>();
            LoadItemsCommand = new Command(async () => await
                ExecuteLoadItemsCommand());

            ItemTapped = new Command<OperationDto>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command<OperationDto>(async (x) =>
            await OnDeleteItem(x));

        }

        private async Task OnDeleteItem(OperationDto operation)
        {
            if (operation == null)
                return;

            var dialog = await Shell.Current.DisplayAlert("Usuwanie", $"Czy napewno chcesz usunąć operacje : {operation.Name}?", "Tak", "Nie");

            if (!dialog)
                return;

            var response = await OperationService.DeleteAsync(operation.Id);

            if (!response.IsSuccess)
                await ShowErrorAlert(response);

            await ExecuteLoadItemsCommand();


        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var response = await OperationService.GetAsync();
                if (!response.IsSuccess)
                    await ShowErrorAlert(response);


                Operations.Clear();

                foreach (var item in response.Data)
                {
                    Operations.Add(item);
                }
            }
            catch (Exception exception)
            {
                await Shell.Current.DisplayAlert(
                                       "Wystąpił błąd",
                                       exception.Message,
                                       "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            
        }


        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(OperationDto operation)
        {
            if (operation == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={operation.Id}");
        }
    }
}