
    $(document).ready(function () {
        var symbol = $("#cryptoCurrencyCandles").attr("name")
        var url = "CryptoCurrencyCoin/GetCandles?coinSymbol=" + symbol;
        if (symbol!=null) {
            $.ajax({
                type: "GET",
                url: url,
                success: function (data) {
                    $("#cryptoCurrencyCandles").html(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                    console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responceText);
                }
            });
        }
    });
