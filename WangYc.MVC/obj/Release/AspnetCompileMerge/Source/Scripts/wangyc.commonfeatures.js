/*******************************************************************
    
    2015.04.25 WangYc 通用JS脚本
    1.转换时间格式为（YYYY-MM-DD）
*******************************************************************/


/*1.转换时间格式*/
function timeformatconversion(fordate) {
    alert("asdf");
    if (fordate == null)
        return "";
    var date = new Date(parseInt(fordate.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}


// add globle object to JQuery, store the url that razon generated.
$.extend({
    Url: {
        Action: function (key) {
            return this[key];
        },
        setUrl: function (key, Url) {
            this[key] = Url;
        }
    }
})