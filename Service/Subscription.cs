//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscription
    {
        public int Id { get; set; }
        public int WorkOutsAmount { get; set; }
        public int WorkOutsPassed { get; set; }
        public decimal Price { get; set; }
        public System.DateTime DateCreateSubscription { get; set; }
        public System.DateTime LastWorkOutDateTime { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
