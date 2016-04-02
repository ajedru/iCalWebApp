# CoffeeScript
window.dateChanged = ->
	date = $('input[id="dateFrom"]').val()
	input = $('input[id="dateTo"]')
	input.datepicker("setStartDate", date)
	input.datepicker("update", date)

$(document).ready(
	debugger
	dateInput = $('input[id="dateFrom"]')

	unless $('.dateRangePicker .form-group').length > 0
		container = $('.dateRangePicker').parent()
	else 
		container = "body"
		
	debugger
	
	dateInput.datepicker(
		format: "dd/mm/yyyy"
		container: container
		todayHighlight: true
		autoclose: true
		todayBtn: true
		startDate: new Date()
	).on('changeDate', dateChanged)
	
	dateInput = $('input[id="dateTo"]')

	dateInput.datepicker(
		format: "dd/mm/yyyy"
		container: container
		todayHighlight: true
		autoclose: true
		todayBtn: true
		startDate: new Date()
	)
)