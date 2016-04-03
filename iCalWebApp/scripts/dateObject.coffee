# CoffeeScript
window.dateChanged = (selected) ->
	input = $('input[id="dateTo"]')
	input.data("DateTimePicker").minDate(selected.date);

$(document).ready(
	dateInput = $('input[id="dateFrom"]')
	
	dateInput.datetimepicker(
		format: "DD/MM/YYYY HH:mm"
		minDate: new moment()
	).on('dp.change', dateChanged)
	
	dateInput = $('input[id="dateTo"]')

	dateInput.datetimepicker(
		format: "DD/MM/YYYY HH:mm"
		minDate: new moment()
	)
)