//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookstore1pf
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.Order_composition = new HashSet<Order_composition>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> date_of_the_order { get; set; }
        public Nullable<int> order_pick_up_point_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<int> status_id { get; set; }
    
        public virtual Customers Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_composition> Order_composition { get; set; }
        public virtual order_pick_up_points order_pick_up_points { get; set; }
        public virtual Statuses Statuses { get; set; }
    }
}