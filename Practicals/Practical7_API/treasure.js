function switchLight(lightID, boolValue)
{
    var lightState = {"on" : boolValue};

    $.ajax({
        url: getLightURI(lightID) + "state",
        type: "PUT",
        data: JSON.stringify(lightState)
    })
}
function switchHue(lightID,value)
{
    var lightHue = {"hue" : value};

    $.ajax({
        url: getLightURI(lightID) + "state",
        type: "PUT",
        data: JSON.stringify(lightHue)
    })
}

function getLightURI(lightID)
{
    var IP = "http://192.168.0.50/api/";
    var username = "stlaB2I6VZ8O80Qepc-1xfmLrHgyTFvB9IGupaQz";
    var lights = "/lights/";
    var URI = IP + username + lights;
    return URI +lightID +"/";
}

function togglelight(element)
{
    var getState = $.getJSON(getLightURI(2), function (data)
    {
        var state = data["state"]["on"];
        if (state)
        {
            state = false;
        }
        else
        {
            state = true;
        }

        switchLight(2, state);
    });
}

function togglelighthue(element)
{
    var getHueColour = document.getElementById("hueChoice").value;
    switchHue(2,parseInt(getHueColour));
}


$(document).ready(function()
{
    $("#lightOn").click(function()
    {
        togglelight($(this));
    })

    $("#lightHue").click(function()
    {
        togglelighthue($(this));
    })

    //variable goes here for generating random number
    //don't forget to create the function to generate said random number

    //now put selector here for working out if they've clicked the button to guess
    //get the guess value and check to see if it matches that random number given above
    //if it does, yippee turn the lights on - send your row number plus a true to switchLight function
    //if it does not - tell the user they've got it wrong

});