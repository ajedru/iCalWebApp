# CoffeeScript
$(document).ready(
	zones = {
	"Central Europe Standard Time" : "Central Europe Standard Time",
	"GMT Standard Time" : "GMT Standard Time",
	"UTC" : "UTC",
	"W. Europe Standard Time" : "W. Europe Standard Time",
	"GTB Standard Time" : "GTB Standard Time"
	"Egypt Standard Time" : "Egypt Standard Time"
	"South Africa Standard Time" : "South Africa Standard Time"
	"Arabic Standard Time" : "Arabic Standard Time"
	"Russian Standard Time": "Russian Standard Time"
	"India Standard Time" : "India Standard Time"
	"China Standard Time" : "China Standard Time"	
	}
	
	for key, value of zones
		$('#timezone-select-from').append("<option value='#{key}'>#{value}</option>") unless $("#timezone-select-from option[value='#{key}']").length > 0
		$('#timezone-select-to').append("<option value='#{key}'>#{value}</option>") unless $("#timezone-select-to option[value='#{key}']").length > 0
)

