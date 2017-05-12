var screenHeight = $(window).innerHeight();
$(window).on("resize", function () {
    if ($(window).innerWidth() > 8) {
        screenHeight = $(window).innerHeight();
        setMainHeight(screenHeight);
    }
}).resize();
$(document).ready(function () {
    setMainHeight(screenHeight);

})

function setMainHeight(height) {
    $('#main-left-nav, #divContentPane').css({ 'height': height - 102, 'min-height': '339px' });
    $('.form-area, .list .tab').css({ 'height': height - 142, 'min-height': '299px' });
}

function freezHeaderTable(tableName) {
    var parent = $('.' + tableName).parent().parent().addClass(tableName + '-parent').attr('class');
    parent = ('.' + parent).replace(/\s/g, '.');
    $(parent + ' div.table-header').html($(parent + ' .table-body').html());
    $(parent + ' div.table-header .' + tableName).removeAttr('id');
}

function freezTableDimension(tableName) {
    var parent = ('.' + tableName + '-parent').replace(/\s/g, '.');
    var headerH = $(parent + ' div.table-header table thead').height();
    $(parent + ' div.table-header').css({ 'height': headerH, 'min-height': 28 });
    $(parent + ' div.table-header table').css('margin-top', 0);
    $(parent + ' div.table-body').css('top', headerH);
    $(parent + ' div.table-body table').css('margin-top', -headerH);
}

function setTableHeight(tableName) {
    tableName = tableName || '';
    var parent = ('.' + tableName + '-parent');
    var tableH = $(parent + ' div.table-header').height() + $(parent + ' div.table-body').height();
    $(parent).css({ 'height': tableH + 19 });
    $(parent).next('.vScroll').css({ 'height': $(parent + ' div.table-body').height() }).find('.vScrollHeight').css({ 'height': $(parent + ' div.table-body tbody').height() });



    $(parent).next('.vScroll').on('scroll', function () {
        $(parent + ' div.table-body').scrollTop($(this).scrollTop());
    });
    $(parent + ' div.table-body').on('scroll', function () {
        $(parent).next('.vScroll').scrollTop($(this).scrollTop());
    });
}





