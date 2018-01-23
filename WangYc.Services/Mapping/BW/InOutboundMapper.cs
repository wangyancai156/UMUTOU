using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class InOutBoundMapper {

        public static InOutBoundView ConvertToInOutBoundView(this InOutBound model) {

            return Mapper.Map<InOutBound, InOutBoundView>(model);
        }

        public static IEnumerable<InOutBoundView> ConvertToInOutBoundView(this IEnumerable<InOutBound> model) {

            return Mapper.Map<IEnumerable<InOutBound>, IEnumerable<InOutBoundView>>(model);
        }

    }
}
