﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Kategori Adi")]
        [StringLength(maximumLength:20,ErrorMessage ="En fazla 20 karakter girebilirsiniz")]
        public string Name { get; set; }

        [DisplayName("Aciklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}