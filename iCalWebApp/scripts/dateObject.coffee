# CoffeeScript
window.dateChanged = (selected) ->
	$('input[id="dateTo"]').data("DateTimePicker").minDate(selected.date);

$(document).ready(
	dateInput = "input[id='dateFrom']"
	if $(dateInput).val() != ""
		curDate = $(dateInput).val()
	else 
		curDate = new moment()
	
	$(dateInput).datetimepicker(
		format: "L LT"
		minDate: curDate
	).on('dp.change', dateChanged)
		
	dateInput = "input[id='dateTo']"	
	if $(dateInput).val() != ""
		curDate = $(dateInput).val()
	else 
		curDate = new moment()

	$(dateInput).datetimepicker(
		format: "L LT"
		minDate: curDate
	)
)