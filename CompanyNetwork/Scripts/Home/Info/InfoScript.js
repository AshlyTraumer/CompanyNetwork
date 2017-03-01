function StartUp(url) {
        Reset();

        $("#IdUp").show();

         $("#datepicker1").datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: new Date(1950, 1, 1),
            autoclose: false
        });

        $("#datepicker2").datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: new Date(1950, 1, 1),
            autoclose: true
        });

        $("#datepicker3").datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: new Date(1950, 1, 1),
            autoclose: true
        });

        $("#datepicker4").datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: new Date(1950, 1, 1),
            autoclose: true
        });    
              
        FilterTable(url, 1);

        $(document).ajaxStart(function () {
            $('#preloader').show();
            $('#ajax').hide();       
            $("#pages").hide();
        })
        .ajaxStop(function () {
            $('#preloader').hide();
            $('#ajax').show();      
            $("#pages").show();
        });
    };

    function Reset() {
        $('#FirstNameUp').hide();
        $('#FirstNameDown').hide();
        $('#SalaryUp').hide();
        $('#SalaryDown').hide();
        $('#DateOfBirthUp').hide();
        $('#DateOfBirthDown').hide();
        $('#DateOfEmploymentUp').hide();
        $('#DateOfEmploymentDown').hide();
        $('#LanguageUp').hide();
        $('#LanguageDown').hide();
        $('#CitizenshipUp').hide();
        $('#CitizenshipDown').hide();
        $('#SexUp').hide();
        $('#SexDown').hide();
        $('#DepartamentTitleUp').hide();
        $('#DepartamentTitleDown').hide();
        $('#IdUp').hide();
        $('#IdDown').hide();
    }

    function FilterTable(url, page, id, save) {
       
        var sortType;

        if ((id != null) && (save == false)) {

            if ($("#" + id + "Up").is(":hidden")) {
                Reset();
                $("#" + id + "Up").show();
                $("#" + id + "Down").hide();
                sortType = false;
            }
            else
                if ($("#" + id + "Down").is(":hidden")) {
                    Reset();
                    $("#" + id + "Down").show();
                    $("#" + id + "Up").hide();
                    sortType = true;
                }
                else
                    Reset();

        }

        $.ajax({
            url: url,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            global: true,
            data:
                JSON.stringify({
                    IsDismissal: $("#isDismissal").prop("checked"),
                    Id: $("#id").val(),
                    FirstName: $("#firstName").val(),
                    SalaryFrom: $("#salaryFrom").val(),
                    SalaryTo: $("#salaryTo").val(),
                    DepartamentTitle: $("#departamentTitle").val(),
                    IsReadyForMoving: $("#isReadyForMoving").prop("checked"),
                    IsReadyForBusinessTrip: $("#isReadyForBusinessTrip").prop("checked"),
                    Language: $("#language").val(),
                    Sex: $("#sex").val(),
                    DateOfBirthFrom: $("#datepicker1").val(),
                    DateOfBirthTo: $("#datepicker2").val(),
                    DateOfEmploymentFrom: $("#datepicker3").val(),
                    DateOfEmploymentTo: $("#datepicker4").val(),
                    Сitizenship: $("#citizenship").val(),
                    CurrentPage: page,
                    SortId: id,
                    IsDesc: sortType
                }),
            success: function (data) {
                Result(data, url);

            }
        });
    }

    function Pager(paginator, currentPage, id, url) {
        var setPages = "";
        for (var i = 0; i < paginator.length; i++) {
            if ((paginator[i] == -1) || (paginator[i] == -2))
                setPages += "<input type='button' value='...'/>";
            else
                if (paginator[i] == currentPage)
                    setPages += "<input type='button' value='" + paginator[i] + "' onClick = 'FilterTable("+'"'+url + '",' + paginator[i] + ',"' + id + '",true' + ")' style='color: red; font-weight: 600;'/>";
                else
                    setPages += "<input type='button' value='" + paginator[i] + "' onClick = 'FilterTable("+'"'+url + '",' + paginator[i] + ',"' + id + '",true' + ")'/>";


        }
        return setPages;
    }

    function Result(data, url) {
        var currentPage = data.currentPage;
        var pages = data.pages;
        var list = data.list;
        var paginator = data.paginator;

        var user = "";
        if (pages != 0) {

            for (var i = 0; i < list.length; i++) {

                user += "<tr><td>";
                user += list[i].Id
                        + "</td><td >"
                        + list[i].Fio
                        + "</td><td>"
                        + list[i].Salary
                        + "</td><td>"
                        + list[i].DateOfBirthFormat
                        + "</td><td>"
                        + list[i].DateOfEmploymentFormat
                        + "</td><td>"
                        + list[i].DateOfDismissalFormat
                        + "</td><td>"
                        + list[i].LanguageFormat
                        + "</td><td>"
                        + list[i].Citizenship.Name
                        + "</td><td>"
                        + list[i].SexFormat
                        + "</td><td>"
                        + list[i].IsReadyForMovingFormat
                        + "</td><td>"
                        + list[i].IsReadyForBusinessTripFormat
                        + "</td><td>"
                        + list[i].DepartamentTitle
                        + "</td></tr>";


                user += "</td></tr>";
            }

            $("#ajax").html(user);

            $("#pages").html(Pager(paginator, currentPage, data.sortColumn, url));
            $("#button").html('<input type="button" value="Show" onclick="FilterTable('+"'"+url+"'"+',1,' + "'" + data.sortColumn + "'" + ')" />');

        }
        else {
            $("#ajax").html("");
            $("#pages").html("");
        }
    }