

function LoadProjectTable() {
  
    var $detailDiv = $('.project-view');
    $('.project-table').DataTable().destroy();

    $('#DataTables_Table_0_length > label').hide();

    $.fn.dataTable.ext.classes.sPageButton = 'btn custom-table-buttons ';

    var dt = $('.project-table').DataTable({
        responsive: {
            details: {
                renderer: function (api, rowIdx, columns) {
                    var data = $.map(columns, function (col, i) {
                        return col.hidden ?
                            '<tr data-dt-row="' + col.rowIndex + '" data-dt-column="' + col.columnIndex + '">' +
                            '<td  class="text-light">' + col.title + ':' + '</td> ' +
                            '<td>' + col.data + '</td>' +
                            '</tr>' :
                            '';
                    }).join('');

                    return data ?
                        $('<table/>').append(data) :
                        false;
                }


            }
        },
        "fnDrawCallback": function (oSettings) {

            $('.project-table').on('click', '.view-project', function (event) {

                event.preventDefault();
                $('body').loading('start');
                $detailDiv.empty();
                $.get('/Account/GetProject?projectId=' + $(this).attr('data-id'), function (data) {

                    $detailDiv.empty().html(data);

                    $('.mode').val('v');
                  
                });


                return false;
            });


            $('.project-table').on('click', '.edit-project', function (event) {
                event.preventDefault();
                $('body').loading('start');
                $detailDiv.empty();
                $.get('/Account/GetProject?projectId=' + $(this).attr('data-id'), function (data) {

                    $detailDiv.empty().html(data);
                    $('.mode').val('e');
            

                });
                return false;
            });


            $('.project-table').on('click', '.notes-project', function (event) {
                event.preventDefault();
                $('body').loading('start');
                $detailDiv.empty();
                $.get('/Account/GetProject?projectId=' + $(this).attr('data-id'), function (data) {

                    $detailDiv.empty().html(data);
                    $('.mode').val('n');
                   

                });
                return false;
            });


            $('.project-table tbody').on('click', 'td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = table.row(tr);

                if (row.child.isShown()) {
                    // This row is already open - close it
                    row.child.hide();
                    tr.removeClass('shown');
                }
                else {
                    // Open this row
                    row.child().show();
                    tr.addClass('shown');
                }
            });

        },
        initComplete: function () {

            this.api().columns([2]).every(function () {
                var column = this;
                var select = $('.select-status')
                    // .appendTo( $(column.footer()).empty() )
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? val : '', false, true)
                            .draw();
                    });

            });

            this.api().columns([3]).every(function () {
                var column = this;
                var select = $('.select-participates').on('change', function () {
                    var val = $.fn.dataTable.util.escapeRegex(
                        $(this).val()
                    );
                    column.search(val ? val : '', false, true).draw();
                });

            });







        },
        paging: true,
        pagingType: 'simple_numbers',
        dom: 'lrtip',
        info: false,
        pageLength: 10,
        header: "jqueryui",
        renderer: "bootstrap",
        language: {
            "zeroRecords": "No records to display with the current search.",
            "emptyTable": "No data available in table"
        },
        columns: [
            {
                "data": null,
                "defaultContent": ""
            },
            { name: 'Project name' },
            { name: 'Status' },
            { name: 'Project Type'},
            { name: 'Assigned Contractors' },
            { name: 'Applicants Alert' },
            { name: 'City' },
            { name: 'State' },
            { name: 'ZipCode' },
            { name: 'Actions' }
        ],
        columnDefs:
            [
                {
                    className: 'control',
                    orderable: true,
                    targets: 0

                },
                {

                    targets: 1,
                    className: 'text-center',
                     orderable: true,
                },
                {

                    targets: 2,
                    className: 'text-center',
                     orderable: true
                },
                {

                    targets: 3,
                    className: 'text-center',
                    orderable: true,
                },
                {

                    targets: 4,
                    className: 'text-center',
                    orderable: false
                },
                {

                    targets: 5,
                    className: 'text-center',
                    orderable: false     

                },
                {

                    targets: 6,
                    className: 'text-center',
                    searchable: false,
                    orderable: false

                },
                {

                    targets: 7,
                    className: 'text-center',
                     orderable: false
                },
                {

                    targets: 8,
                    className: 'text-center',
                     orderable: false
                },

                {
                    targets: 9,
                    searchable: false,
                    orderable: false
                }
            ]
    });


    $('.project-search').on('keyup', function () {
        dt.search(this.value).draw();
    });
}

function SetStars(star, index) {


    //star.on('mouseover', function () {
    //    var index = $(this).attr('data-index');
    //    markStarsAsActive(index);
    //});

    markStarsAsActive('' + index - 1 + '');

    function markStarsAsActive(index) {
        unmarkActive();

        for (var i = 0; i <= index; i++) {
            switch (index) {
                case '0':
                    $(star.get(i)).addClass('oneStar');
                    break;
                case '1':
                    $(star.get(i)).addClass('twoStars');
                    break;
                case '2':
                    $(star.get(i)).addClass('threeStars');
                    break;
                case '3':
                    $(star.get(i)).addClass('fourStars');
                    break;
                case '4':
                    $(star.get(i)).addClass('fiveStars');
                    break;
            }
        }
    }

    function unmarkActive() {
        star.removeClass('oneStar twoStars threeStars fourStars fiveStars');
    }

    star.on('click', function (e) {


        if (star.hasClass("oneStar")) {
            console.log('1' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("twoStars")) {
            console.log('2' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("threeStars")) {
            console.log('3' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("fourStars")) {
            console.log('4' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("fiveStars")) {
            console.log('5' + $(this).attr('data-contractor'));
        }

    });



}

function MouseOverSetStars(star, index) {

    
    star.on('mouseover', function () {
        index = $(this).attr('data-index');
        markStarsAsActive(index);
    });

    markStarsAsActive('' + index - 1 + '');

    function markStarsAsActive(index) {
        unmarkActive();

        for (var i = 0; i <= index; i++) {
            switch (index) {
                case '0':
                    $(star.get(i)).addClass('oneStar');

                    break;
                case '1':
                    $(star.get(i)).addClass('twoStars');

                    break;
                case '2':
                    $(star.get(i)).addClass('threeStars');

                    break;
                case '3':
                    $(star.get(i)).addClass('fourStars');

                    break;
                case '4':
                    $(star.get(i)).addClass('fiveStars');
                    break;
            }
        }
    }

    function unmarkActive() {
        star.removeClass('oneStar twoStars threeStars fourStars fiveStars');
    }

    star.on('click', function (e) {


        var projectId = $(this).attr('data-projectId');
        var ApplicantId = $(this).attr('data-applicantId');



        if (star.hasClass("oneStar")) {
            $.ajax({
                type: "POST",
                url: '/Account/UpdateApplicantRating?projectId=' + projectId + '&ApplicantId=' + ApplicantId + '&rating=1' ,
                success: function () {
                   
                }
            });
            return false;
        }

        if (star.hasClass("twoStars")) {
            $.ajax({
                type: "POST",
                url: '/Account/UpdateApplicantRating?projectId=' + projectId + '&ApplicantId=' + ApplicantId + '&rating=2',
                success: function () {

                }
            });
            return false;
        }

        if (star.hasClass("threeStars")) {
            $.ajax({
                type: "POST",
                url: '/Account/UpdateApplicantRating?projectId=' + projectId + '&ApplicantId=' + ApplicantId + '&rating=3',
                success: function () {

                }
            });
            return false;
        }

        if (star.hasClass("fourStars")) {
            $.ajax({
                type: "POST",
                url: '/Account/UpdateApplicantRating?projectId=' + projectId + '&ApplicantId=' + ApplicantId + '&rating=4',
                success: function () {

                }
            });
            return false;
        }

        if (star.hasClass("fiveStars")) {
            $.ajax({
                type: "POST",
                url: '/Account/UpdateApplicantRating?projectId=' + projectId + '&ApplicantId=' + ApplicantId + '&rating=5',
                success: function () {

                }
            });
            return false;
        }

    });



}

function MouseOverSetStars2(star, index) {


    star.on('mouseover', function () {
        index = $(this).attr('data-index');
        markStarsAsActive(index);
    });

    markStarsAsActive('' + index - 1 + '');

    function markStarsAsActive(index) {
        unmarkActive();

        for (var i = 0; i <= index; i++) {
            switch (index) {
                case '0':
                    $(star.get(i)).addClass('oneStar');

                    break;
                case '1':
                    $(star.get(i)).addClass('twoStars');

                    break;
                case '2':
                    $(star.get(i)).addClass('threeStars');

                    break;
                case '3':
                    $(star.get(i)).addClass('fourStars');

                    break;
                case '4':
                    $(star.get(i)).addClass('fiveStars');
                    break;
            }
        }
    }

    function unmarkActive() {
        star.removeClass('oneStar twoStars threeStars fourStars fiveStars');
    }

    star.on('click', function (e) {


        var projectId = $(this).attr('data-projectId');
        var ApplicantId = $(this).attr('data-applicantId');



        if (star.hasClass("oneStar")) {
            $('.StarRatng').val('1');
            return false;
        }

        if (star.hasClass("twoStars")) {
            $('.StarRatng').val('2');
            return false;
        }

        if (star.hasClass("threeStars")) {
            $('.StarRatng').val('3');
            return false;
        }

        if (star.hasClass("fourStars")) {
            $('.StarRatng').val('4');
            return false;
        }

        if (star.hasClass("fiveStars")) {
            $('.StarRatng').val('5');
            return false;
        }

    });



}


$(document).ready(function () {




    // this is for the is contractor checkbox that makes it 'customer or contractor'
    $('.IsContractor').checkboxpicker({
        html: true,
        offLabel: 'Customer',
        onLabel: 'Contractor'
    }).on('change', function () {
        $('.dont-forget').show();

        switch ($(this).is(":checked")) {
            case true:
                $('.IsContractor').prop('checked', true);
                $('.current-mode').html('<span style="color:#015668;font-size:1rem">Contractor</span>');
                $('.contractor-customer-change').val('true');
                $('.cm').val('true');
                break;
            case false:
                $('.IsContractor').prop('checked', false);
                $('.current-mode').html('<span style="color:#015668;font-size:1rem">Customer</span>');
                $('.contractor-customer-change').val('true');
                $('.cm').val('false');
                break;
        }

    });


    $('.InWorkMode').checkboxpicker({
        html: true,
        offLabel: 'Off Work',
        onLabel: 'Ready for hire'
    }).on('change', function () {


        switch ($(this).is(":checked")) {
            case true:
                $('.InWorkMode').prop('checked', true);
                $('.current-work-mode').html('<span style="color:#015668;font-size:1rem">Ready for hire</span>');
                break;
            case false:
                $('.InWorkMode').prop('checked', false);
                $('.current-work-mode').html('<span style="color:#015668;font-size:1rem">Off Work</span>');
                break;
        }

    });

    $('.ContactByEmail').checkboxpicker({
        html: true,
        offLabel: 'No',
        onLabel: 'Yes'
    }).on('change', function () {


        switch ($(this).is(":checked")) {
            case true:
                $('.ContactByEmail').prop('checked', true);
                $('.ContactByEmailMode').html('<span style="color:#015668;font-size:1rem">Yes</span>');
                break;
            case false:
                $('.ContactByEmail').prop('checked', false);
                $('.ContactByEmailMode').html('<span style="color:#015668;font-size:1rem">No</span>');
                break;
        }

    });

    $('.ContactByPhone').checkboxpicker({
        html: true,
        offLabel: 'No',
        onLabel: 'Yes'
    }).on('change', function () {


        switch ($(this).is(":checked")) {
            case true:
                $('.ContactByPhone').prop('checked', true);
                $('.ContactByPhoneMode').html('<span style="color:#015668;font-size:1rem">Yes</span>');
                break;
            case false:
                $('.ContactByPhone').prop('checked', false);
                $('.ContactByPhoneMode').html('<span style="color:#015668;font-size:1rem">No</span>');
                break;
        }

    });

    $('.Verification-chk').checkboxpicker({
        html: true,
        offLabel: 'No',
        onLabel: 'Yes'
    }).on('change', function () {


        switch ($(this).is(":checked")) {
            case true:
                $('.Verification-chk').prop('checked', true);
                $('.Verification-mode').html('<span style="color:#015668;font-size:1rem">Yes</span>');
                $('.div-GAuthEnable').show();
                break;
            case false:
                $('.Verification-chk').prop('checked', false);
                $('.Verification-mode').html('<span style="color:#015668;font-size:1rem">No</span>');
                $('.div-GAuthEnable').hide();
                break;
        }

    });
    
    

    $('a[data-toggle="tooltip"]').tooltip({
        animated: 'fade',
        placement: 'bottom',
        html: true
    });
  

    // this sets the hourly amout to a $format 
    $('.currency').currencyFormat();


   


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




    $('.ApplicationUser-Professions').hide();
    $('.ApplicationUser-SubProfessions').hide();
    $('.ApplicationUser-add').hide();

    $('.ApplicationUser-skills .Alphabetical').click(function () {
        $('.ApplicationUser-Professions').show();
        $.getJSON('/Account/AutoComplete', { term: this.innerText }, function (item) {

            $('.ApplicationUser-Professions').empty();
            $('.ApplicationUser-Professions').append("<option value='- Please Select A Profession Category -'>- Please Select A Profession Category -</option>");

            $.each(item, function (index, data) {
                $('.ApplicationUser-Professions').append("<option value='" + data.ID + "'>" + data.Name + "</option>");
            });

        });
    });

    $('.ApplicationUser-Professions').change(function (event, ui) {
        $.get('/Account/GetSubCategoryList', { Id: this.value }, function (data) {

            $('.ApplicationUser-SubProfessions').empty();
            $('.ApplicationUser-SubProfessions').show();

            $('.ApplicationUser-SubProfessions').append("<option value='- Please Select A Job Title -'>- Please Select A Job Title -</option>");
            $.each(data, function (index, row) {
                $('.ApplicationUser-SubProfessions').append("<option data-info='" + $(".ApplicationUser-Professions option:selected").text() + "'  value='" + this.MainCatId + '_' + row.Id + "'>" + row.SubCatNames + "</option>");

            });
        });
    });

    $('.ApplicationUser-SubProfessions').change(function (event, ui) {
        if ($(".ApplicationUser-SubProfessions option:selected").val() !== '- Please Select A Job Title -') {
            $('.ApplicationUser-add').show();
        }
    });

   
 
    $('.ApplicationUser-add').click(function () {

        var json="";

        if ($(".ApplicationUser-SubProfessions option:selected").val() !== '- Please Select A Job Title -') {      

            $('.ApplicationUser-result').append('<div class="result-added new" id="' + $(".ApplicationUser-SubProfessions option:selected").val() + '"><span class="btn btn-dark btn-sm " role="button" style="margin: 5px;">X</span>' + $(".ApplicationUser-Professions option:selected").text() + ' -- ' + $(".ApplicationUser-SubProfessions option:selected").text() + '</div>')

            // updates the hidden field
            $('.ApplicationUser-skills .new').each(function (index, value) {
                json += $(".ApplicationUser-SubProfessions option:selected").val() + ',';
            });
            //sets the hidden field for postback
            $('#JsonProfession').val(json);

            //add cat and sub cat
            var mainID = $(".ApplicationUser-Professions option:selected").val();
            var subID = $(".ApplicationUser-SubProfessions option:selected").val().split('_')[1];
           
            $.post('/Account/AddUserContractorCustomerCategories', { json: $('#JsonProfession').val() }, function (data) { });

            // remove the selected one after we add it
            $('.ApplicationUser-SubProfessions').find('option:selected').remove().end();
        }
        else {
            alert('Please Select A Job Title');
        }

    });

    $('.ApplicationUser-remove').click(function (e) {

        $(this).parent().remove();

        $.post('/Account/RemoveUserContractorCustomerCategories', { mainId: $(this).attr('data-id').split(" ")[0], subId: $(this).attr('data-id').split(" ")[1] }, function (data) {

        });

    });





});

$('.currency').currencyFormat();

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
                url: '/Account/RemoveUpload?type=profile',
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
    url: "/Account/Upload?type=id",
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
        $('.IdImage').append('<img style="margin-bottom:10px;" class="img-thumbnail" src="/Uploads/ProfileImages/' + $('#Id').val() + '/' + response.Message + '"> <button class="btn remove-idimage">X</button>');

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

$("#dropzoneProfileResume").dropzone({
    url: "/Account/Upload?type=resume",
    init: function () {
        this.on("error", function (file, message, xhr) {
            if (xhr === null) this.removeFile(file);

            $('.dropzone-error2').append(message);
        });
    },
    addRemoveLinks: false,
    uploadMultiple: false,
    createImageThumbnails: false,
    acceptedFiles: ".pdf",
    dictDefaultMessage: "Upload your resume in PDF.",
    success: function (file, response) {
        swal("We have received your resume", "success");
        $('.profile-resume').get(0).src = $('.profile-resume').attr('data-url');
       
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    complete: function (file, response) {
        this.removeAllFiles(true);
    }


});