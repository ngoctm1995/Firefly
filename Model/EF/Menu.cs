namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public string Link { get; set; }

        public int DisplayOrder { get; set; }

        public string Target { get; set; }
        public bool Startus { get; set; }
        public int TypeID { get; set; }
    }
}
