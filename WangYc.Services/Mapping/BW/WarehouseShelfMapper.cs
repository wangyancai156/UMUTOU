using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class WarehouseShelfMapper {
        public static WarehouseShelfView ConvertToWarehouseShelfView(this WarehouseShelf model) {

            return Mapper.Map<WarehouseShelf, WarehouseShelfView>(model);
        }

        public static IEnumerable<WarehouseShelfView> ConvertToWarehouseShelfView(this IEnumerable<WarehouseShelf> model) {

            return Mapper.Map<IEnumerable<WarehouseShelf>, IEnumerable<WarehouseShelfView>>(model);
        }
    }
}

 