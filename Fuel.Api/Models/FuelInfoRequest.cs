namespace Fuel.Api.Models
{
    using Fuel.Api.Helpers.Binders;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FuelInfoRequest
    {
        [Required]
        public int DriverId { get; set; }

        [Required]
        [ModelBinder(BinderType = typeof(DateTimeModelBinder), Name = "fromDate")]
        public DateTime FromDate { get; set; }

        [Required]
        [ModelBinder(BinderType = typeof(DateTimeModelBinder), Name = "toDate")]
        public DateTime ToDate { get; set; }
    }
}
