namespace CampusSystem.Web.Areas.Administration.ViewModels.Building
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ConsumptionViewModel : IMapFrom<Consumption>
    {
        public string RoomName { get; set; }

        public double Electricity { get; set; }

        public double ColdWater { get; set; }

        public double HotWater { get; set; }

        public double Heating { get; set; }

        public string Month { get; set; }
    }
}