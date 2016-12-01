function GetPlayers(TeamId) {
    var procemessage = "<option value='0'> Please wait...</option>";
    $("#ddlcity").html(procemessage).show();
    var url = "/Test/GetCityByStaeId/";

    $.ajax({
        url: url,
        data: { stateid: _stateId },
        cache: false,
        type: "POST",
        success: function (data) {
            var markup = "<option value='0'>Select City</option>";
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            $("#ddlcity").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });

}