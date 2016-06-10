# CoffeeScript
$(document).ready(
	zones = {
	"GM" : "GMT Standard Time",
	"UT" : "UTC",
	"WE" : "W. Europe Standard Time",
	"CE" : "Central Europe Standard Time",
	"GT" : "GTB Standard Time"
	"EG" : "Egypt Standard Time"
	"SA" : "South Africa Standard Time"
	"AS" : "Arabic Standard Time"
	"RU" : "Russian Standard Time"
	"IS" : "India Standard Time"
	"CH" : "China Standard Time"	
	}
	
	for key, value of zones
		$('#timezone-select-from').append("<option value='#{key}'>#{value}</option>") unless $("#timezone-select-from option[value='#{key}']").length > 0
		$('#timezone-select-to').append("<option value='#{key}'>#{value}</option>") unless $("#timezone-select-to option[value='#{key}']").length > 0
)

