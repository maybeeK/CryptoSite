$("input[type='checkbox']").bind("change", function () {
    var url = "/Favourite";
    var mode;
    var antiForgeryToken = $("input[name='__RequestVerificationToken']").val();

    var userModel = {
        __RequestVerificationToken: antiForgeryToken,
        Id: $(this).attr("value"),
        CoinName: $(this).attr("name")
    };

    if (userModel.Id == null) {
        location.href = "/Identity/Account/Login";
        return;
    }

    if ($(this).is(":checked")) {
        mode = "/AddToFavourite";
    }
    else {
        mode = "/RemoveFromFavourite";
    }

    url += mode;

    $.ajax(
        {
            type: "POST",
            url: url,
            data: userModel,
            error: function (xhr, ajaxOptions, thrownError) {
                    var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                    console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responceText);
            }
        }
    );

    // ajax code here
});