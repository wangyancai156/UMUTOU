using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Models.SD;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.Mapping.SD {
    public static class ProductMapper {

        public static ProductView ConvertToProductView(this Product model) {

            return Mapper.Map<Product, ProductView>(model);
        }

        public static IEnumerable<ProductView> ConvertToProductView(this IEnumerable<Product> model) {

            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(model);
        }
    }
}
