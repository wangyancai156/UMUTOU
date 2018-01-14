// =============================================
// Author:	M56
// Create date: 10:04 2012-11-14
// Description:	Set Combobox Selected Item By Item Index
// use method: $('#comboboxID').combobox('setIndex',SelectedIndex); 
// =============================================
$.extend($.fn.combobox.methods, {
    setIndex: function (jq, index) {
        if (!index)
            index = 0;
        var mydata = $(jq).combobox('getData');
        var tf = $(jq).combobox('options').textField;
        $.each(mydata, function (i, n) {
            if (index == i) {
                $(jq).combobox('setValue', eval('n.' + tf));
            }
        });
    }
});