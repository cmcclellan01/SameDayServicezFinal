// this is for the is contractor checkbox that makes it 'customer or contractor'
$('.IsContractor').checkboxpicker({
    html: true,
    offLabel: 'Customer',
    onLabel: 'Contractor'
}).on('change', function () {


    switch ($(this).is(":checked")) {
        case true:
            $('.IsContractor').prop('checked', true);
            $('.current-mode').text('Current Mode: Contractor');
            break;
        case false:
            $('.IsContractor').prop('checked', false);
            $('.current-mode').text('Current Mode: Customer');
            break;
    }

});

Dropzone.autoDiscover = false;
$("#dropzoneProfilePic").dropzone({
    init: function () {
        this.on("error", function (file, message, xhr) {
            if (xhr === null) this.removeFile(file);

            $('.dropzone-error').append(message);
        });
    },
    url: "/Account/Upload?type=profile",
    addRemoveLinks: false,
    createImageThumbnails: false,
    uploadMultiple: false,
    acceptedFiles: ".jpeg,.jpg,.png",
    dictDefaultMessage: "  Upload a photo of yourself for your contractor profile.",
    success: function (file, response) {
        $('.ProfileImage').empty();
        $('.ProfileImage').append('<img style="margin-bottom:10px;" class="img-thumbnail" src="/Uploads/ProfileImages/' + $('#Id').val() + '/' + response.Message + '"> <button class="btn remove-profileimage">X</button>');

        $('.remove-profileimage').click(function () {
            $.ajax({
                type: "POST",
                url: 'Account/RemoveUpload?type=profile',
                success: function () {
                    $('.ProfileImage').empty();
                }
            });
            return false;
        });
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    complete: function (file, response) {
        this.removeAllFiles(true);
    }

});


$("#dropzoneIdPic").dropzone({
    url: "Account/Upload?type=id",
    init: function () {
        this.on("error", function (file, message, xhr) {
            if (xhr === null) this.removeFile(file);

            $('.dropzone-error2').append(message);
        });
    },
    addRemoveLinks: false,
    uploadMultiple: false,
    createImageThumbnails: false,
    acceptedFiles: ".jpeg,.jpg,.png",
    dictDefaultMessage: "Upload a scan of your driver's license or government issued photo ID.",
    success: function (file, response) {
        $('.IdImage').empty();
        $('.IdImage').append('<img style="margin-bottom:10px;" class="img-thumbnail" src="/Uploads/ProfileImages/' + $('#Id').val() + '/' + response.Message + '"> <button class="btn remove-idiimage">X</button>');

        $('.remove-idimage').click(function () {
            $.ajax({
                type: "POST",
                url: '/Account/Upload?type=id',
                success: function () {
                    $('.IdImage').empty();
                }
            });
            return false;
        });
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    complete: function (file, response) {
        this.removeAllFiles(true);
    }


});

$(document).ready(function () {

    

    // this sets the hourly amout to a $format 
    $('.currency').currencyFormat();


    // hide the sub cat list until ready
    $('.Professions').hide();
    $('.SubProfessions').hide();
    $('.update-professions').hide();

    var json = "";
    $('.remove-profileimage').click(function () {
        $.ajax({
            type: "POST",
            url: '/Account/RemoveUpload?type=profile',
            success: function () {
                $('.ProfileImage').empty();
            }
        });
        return false;
    });

    $('.remove-idimage').click(function () {
        $.ajax({
            type: "POST",
            url: '/Account/RemoveUpload?type=id',
            success: function () {
                $('.IdImage').empty();
            }
        });
        return false;
    });





    $('.Alphabetical').click(function () {
        $('.Professions').show();
        $.getJSON('/Account/AutoComplete', { term: this.innerText }, function (item) {

            $("#Professions").empty();
            $("#Professions").append("<option value='- Please Select A Profession Category -'>- Please Select A Profession Category -</option>");

            $.each(item, function (index, data) {
                $("#Professions").append("<option value='" + data.ID + "'>" + data.Name + "</option>");
            });

        });
    });



    $('#Professions').change(function (event, ui) {
        $.get('/Account/GetSubCategoryList', { Id: this.value }, function (data) {

            $("#SubProfessions").empty();
            $(".SubProfessions").show();

            $("#SubProfessions").append("<option value='- Please Select A Job Title -'>- Please Select A Job Title -</option>");
            $.each(data, function (index, row) {
                $("#SubProfessions").append("<option data-info='" + $("#Professions option:selected").text() + "'  value='" + this.MainCatId + '_' + row.Id + "'>" + row.SubCatNames + "</option>");

            });


        });
    });


    // add new sub(s) from list
    $('.add').click(function () {

        if ($("#SubProfessions option:selected").val() !== '- Please Select A Job Title -') {

            $('.update-professions').show();

            //empty the textbox and setup for next search
            $('#SelectedProfession').val('');
            $('.sublist').hide();

            $('.results').append('<div class="result-added new" id="' + $("#SubProfessions option:selected").val() + '"><span class="btn btn-outline-danger btn-sm " role="button" style="margin: 5px;">remove</span>' + $("#Professions option:selected").text() + ' -- ' + $("#SubProfessions option:selected").text() + '</div>')

            // updates the hidden field
            $('.new').each(function (index, value) {
                json += $("#SubProfessions option:selected").val() + ',';
            });
            //sets the hidden field for postback
            $('#JsonProfession').val(json);

            // remove the selected one after we add it
            $('#SubProfessions').find('option:selected').remove().end();
        }
        else {
            alert('Please Select A Job Title');
        }

    });

    $('.remove').click(function (e) {

        $(this).parent().remove();

        $.post('/Account/RemoveUserContractorCustomerCategories', { mainId: $(this).attr('data-id').split(" ")[0], subId: $(this).attr('data-id').split(" ")[1] }, function (data) {

        });

    });


   

   

    $('#BirthDate').datepicker({
        uiLibrary: 'bootstrap4',
        dateFormat: 'mm/dd/yy'
    });


    $('.save-profile').on('click', function (event) {
        $("#form-profile").submit();
    });

    $('.submit').on('click', function (event) {
        event.preventDefault();
        getGeoCode();
       
       
    });


    function getGeoCode() {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': "'" + $('#Address').val() + $('#City').val() + $("#State option:selected").val() + $('#ZipCode').val() + "'" }, function (results, status) {
            if (status === 'OK') {
                $('#latitude').val(results[0].geometry.location.lat());
                $('#longitude').val(results[0].geometry.location.lng());

                //  $("#BasicInfo").submit();

                $("#accordion").accordion("option", "active", 1);

                $("#form-profile").submit();
            } else {
                result = 'Unable to find address: ' + status;
                event.preventDefault();
            }

        });
    }

});