using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Factory.Modelos;
using Factory.Services;
using Xamarin.Forms;

namespace Factory.Views
{
    public partial class Clientes : ContentPage
    {
        public List<ModelListClientes> CliList = new List<ModelListClientes>();
        public Clientes()
        {
            InitializeComponent();
            //ListaClientes.ItemsSource = new List<ModelListClientes>
            //{
            //    new ModelListClientes { numero = "1", nombre = "Salinas Vargas Katerine ", cupo= "5,000", saldo ="10.00" },
            //    new ModelListClientes { numero = "2", nombre = "Valverde Lopez Gloria ", cupo= "5,000", saldo ="0.00"},
            //};
            _ = InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            var client1 = new ClienteServices();
            ListaClientes.ItemsSource = CliList = await client1.GetCliListClienteAsync(Global.numvendedor);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var cliente = e.SelectedItem as ModelListClientes;
            DisplayAlert("Selected", "Cliente " + cliente.nombre,"OK");

            if (e.SelectedItem != null)
            {
                ModelProducto modelProducto = (ModelProducto)e.SelectedItem;
                Navigation.PushAsync(new CDetallesGeneral(cliente));
            }
                    ((ListView)sender).SelectedItem = null;
        }
    }
}
