$("input[type='checkbox']").bind("change", function () {
    var url = "/Favourite";
    var mode;
    var antiForgeryToken = $("input[name='__RequestVerificationToken']").val();

    var userModel = {
        __RequestVerificationToken: antiForgeryToken,
        Id: $(this).attr("value"),
        CoinName: $(this).attr("name")
    };


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
            success: function (data) {
                alert("success");

            },
            error: function (xhr, ajaxOptions, thrownError) {
                    var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                    console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responceText);
            }
        }
    );

    // ajax code here
});