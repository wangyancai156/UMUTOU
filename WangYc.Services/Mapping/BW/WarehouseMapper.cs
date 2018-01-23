using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class WarehouseMapper {
        public static WarehouseView ConvertToWarehouseView(this Warehouse model) {

            return Mapper.Map<Warehouse, WarehouseView>(model);
        }

        public static IEnumerable<WarehouseView> ConvertToWarehouseView(this IEnumerable<Warehouse> model) {

            return Mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseView>>(model);
        }
    }
}
