$(document).ready(function () {
    $('.datefield').datepicker($.datepicker.regional['hr']);
    $('.datefield').datepicker('option', 'changeMonth', true);
    $('.datefield').datepicker('option', 'changeYear', true);
    $('.datefield').datepicker('option', 'yearRange', '-1:+1');
    $('.datefield').datepicker('option', 'showAnim', 'slideDown');
});