function EnableSearchAutocomplete(url, img) {
    var formatItem = function (row) {
        if (!row) return "";
        return "<a href='" + row[1] + "' target='_blank' ><span class='label label - success'>مقاله</span>" + row[0] +"</a>";
    }

    $(document).ready(function () {
        
        $("#term").autocomplete(url, {
            dir: 'rtl', minChars: 3, delay: 5,
            mustMatch: false, max: 20, autoFill: false,
            matchContains: false, scroll: false, width: 300,
            formatItem: formatItem 
        }).result(function (evt, row, formatted) {
            if (!row) return;
           
            window.location = row[1];
        });
    });
}