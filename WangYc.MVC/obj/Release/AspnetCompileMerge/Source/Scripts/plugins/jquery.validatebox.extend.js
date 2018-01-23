$.extend($.fn.validatebox.defaults.rules, {
    maxLength: {
        validator: function (value, param) {
            return value.length <= param[0];
        },
        message: '长度不能大于{0}'
    },
    mobile: {
        validator: function (value, param) {
            return /^[0-9]{5,20}$/.test(value);
        },
        message: '手机号码不正确'
    },
    buyerstaxno: {
        //纳税人识别号,一律由15位、17位、18位或者20位码（字符型）组成
        validator: function (value, param) {
            if (value.length == 15 || value.length == 17 || value.length == 18 || value.length == 20) {
                return true;
            }
            return false;
        },
        message: '税号一律由15位、17位、18位或者20位码（字符型）组成'
    },
    equalTo: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: '两次输入的字符不一致'
    },
    number: {
        validator: function (value, param) {
            return /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test(value);
        },
        message: '请输入数字'
    },
    dateTime: {
        validator: function (value, param) {
            var regex = "^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            var exp = new RegExp(regex, "i");
            var flag = true;
            if (value.length > 0) {
                flag = exp.test(value);
            }
            return flag;
        }, 
        message: '请输入合法的日期格式,如1992-01-01'
    },
    areaCode: {
        validator: function (value, param) {
            
            var regex = /^\d*$/;
            return regex.test(value);
        },
        message: '请输入正确的区号,必须为数字'
    },
    telOrFaxNumber: {
        validator: function (value, param) {
            var regex = /^\d*$/;
            return regex.test(value);
        },
        message: '请输入正确的号码,必须为数字'
    },
    ext: {
        validator: function (value, param) {
            var regex = /^\d*$/;
            return regex.test(value);
        },
        message: '请输入正确的分机号码,必须为数字'
    },
    zip: {
        validator: function (value, param) {
            return /^[1-9]\d{5}$/.test(value);
        },
        message: '请输入正确的邮政编号,长度为6位的数字'
    },
    password: {
        validator: function (value, param) {
            return /^[a-zA-Z0-9]{6,18}$/.test(value);
        },
        message: '密码必须是6-18个字符，包括英文字母、数字'
    },
    userName: {
        validator: function (value, param) {
            return /^[a-zA-Z][a-zA-Z0-9_\.@]{4,28}[a-zA-Z0-9]$/.test(value);
        },
        message: '6~30个字符，包括字母、数字、下划线，以字母开头，字母或数字结尾'
    },
    xyz: {
        validator: function (value, param) {
            return /^[a-zA-Z]{1,5}$/.test(value);
        },
        message: '姓名简称只能是英文字母，长度不大于5'
    }
});