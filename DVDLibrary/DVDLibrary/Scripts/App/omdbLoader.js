var queryStringStart = 'http://www.omdbapi.com/?t=';
var queryStringEnd = '&y=&plot=full&r=json';

$('#dvd-search').submit(function () {
    var selector = $('#SearchForDvd').val()
        var querySelector = selector.replace(/\s+/g, '+');
        var queryString = queryStringStart + querySelector + queryStringEnd;
        $.getJSON(queryString).done(function (data) {
            if (data.Response == "False") {
                changeHidden();
                $('#ErrorText').removeClass('hidden');
                $('#Title').val(selector);
            }
            else {
                changeHidden()
                //console.log(data);
                for (var i in data) {
                    $('input[id="' + i + '"]').val(data[i])
                }
            }
        });
    return false;
});



function changeHidden() {
    $('#SearchBox').addClass('hidden');
    $('#dvdform').removeClass('hidden');
    
}