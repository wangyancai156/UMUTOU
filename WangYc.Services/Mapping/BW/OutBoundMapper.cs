using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class OutBoundMapper {
        public static OutBoundView ConvertToOutBoundView(this OutBound model) {

            return Mapper.Map<OutBound, OutBoundView>(model);
        }

        public static IEnumerable<OutBoundView> ConvertToOutBoundView(this IEnumerable<OutBound> model) {

            return Mapper.Map<IEnumerable<OutBound>, IEnumerable<OutBoundView>>(model);
        }
    }
}
