
$("#accordion").accordion({
    heightStyle: "content",
    collapsible: true
});

$('#BirthDate').datepicker({
    uiLibrary: 'bootstrap4',
    dateFormat: 'mm/dd/yy'
});


$('#Register').on('click', function (event) {
    event.preventDefault();
    getGeoCode();
});


function getGeoCode() {
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': "'" + $('#Address').val() + $('#City').val() + $("#State option:selected").val() + $('#ZipCode').val() + "'" }, function (results, status) {
        if (status === 'OK') {
            $('#latitude').val(results[0].geometry.location.lat());
            $('#longitude').val(results[0].geometry.location.lng());

            $("#Register").submit();
        } else {
            result = 'Unable to find address: ' + status;
            event.preventDefault();
        }

    });
}