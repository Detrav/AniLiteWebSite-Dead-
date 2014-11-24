BSFGAdd = function(name,placeholder)
{
    $("#Add" + name).before('<div class="input-group"><input class="form-control" placeholder="' + placeholder + '" type="text"><span class="input-group-btn"><a class="btn btn-danger">Удалить</a></span></div>');
    BSFGRenameInputs(name);
}

BSFGDelete = function(name,num)
{
    $(".js-for-" + name + " .input-group").each(function (i, val) {
        if(num==i)
        {
            $(val).remove();
        }
        });
    BSFGRenameInputs(name);
}

BSFGRenameInputs = function(name)
{
    $(".js-for-" + name + " .input-group").each(function (i, val) {
        var ch = $(val).find("input");
        $(ch[0]).attr('id', name + '['+i+']');
        $(ch[0]).attr('name', name + '[' + i + ']');
        ch = $(val).find("a");
        $(ch[0]).attr('onclick', "BSFGDelete('"+name+"','"+i+"')");
        $(ch[0]).attr('name', 'Delere'+name);
    });
}

BSFGTestImg = function(name)
{
    $(".test-image-for-" + name).attr("src", $("#" + name).val());
}

$(".datepicker").datepicker({ changeMonth: true, changeYear: true, dateFormat: 'dd.mm.yy' });

BSFGPlus = function (name)
{
    $("#" + name).val(parseInt($("#" + name).val(), 0) + 1)

}
BSFGMinus = function (name)
{
    $("#" + name).val(parseInt($("#" + name).val(), 0) - 1)
}