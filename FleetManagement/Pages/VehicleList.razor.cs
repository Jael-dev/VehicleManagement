﻿using Blazorise;
using FleetManagement.ClientServices;
using FleetManagement.Data;
using Microsoft.AspNetCore.Components;
using Shared.ApiModels;

namespace FleetManagement.Pages
{
    public partial class VehicleList
    {
        [Inject]
        public IVehicleServices VehicleServices { get; set; }

        public IEnumerable<VehicleModel?> Vehicles { get; set; }= new List<VehicleModel?>();



        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Vehicles = await VehicleServices.GetAllVehiclesAsync();
        }

        private async Task AddVehicle(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            await _modalRef.Show();
        }

        private async Task VehicleEdited()
        {
            
            await _modalRef.Hide();
            Vehicle= new VehicleModel();
            Vehicles = await VehicleServices.GetAllVehiclesAsync();
        }

        private void EditVehicle (VehicleModel vehicle)
        {
            Vehicle = vehicle;
            _modalRef.Show();
        }

        

        private Modal _modalRef;

        VehicleModel Vehicle = new VehicleModel();




    }

}
